using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Web;
using System.Windows.Forms;
namespace CrystalLibrary
{
    public class CrystalConnector : IDisposable
    {
        private string _datebaseName;
        private string _serverName;
        private string _userId;
        private string _password;
        private bool _integratedSecurity;
        private ReportDocument _reportDocument;
        private DataSet _reportData;
        private string _reportFile;
        private bool _reportIsOpen;
        private bool _assignDataSourceAllReports = false;
        private string _recordSelection;
        private string _sqlQuery;
        private SortedList<string, object> _parameters;
        private SortedList<string, object> _formulas;
        public ReportDocument ReportSource
        {
            get
            {
                return this._reportDocument;
            }
            set
            {
                if (this._reportDocument != null)
                {
                    this._reportDocument.Dispose();
                }
                this._reportDocument = value;
                if (value == null)
                {
                    this._reportFile = null;
                }
            }
        }
        public string ReportFile
        {
            get
            {
                return this._reportFile;
            }
            set
            {
                if (this._reportDocument != null)
                {
                    this._reportDocument.Dispose();
                }
                if (value != null && value.Trim().Length > 0)
                {
                    this._reportDocument = this.CreateReportDocument(value);
                }
                else
                {
                    this._reportFile = value;
                    this._reportDocument = null;
                }
            }
        }
        public DataSet DataSource
        {
            get
            {
                return this._reportData;
            }
            set
            {
                if (this._reportData != null)
                {
                    this._reportData.Dispose();
                }
                this._reportData = value;
            }
        }
        public string ServerName
        {
            get
            {
                return this._serverName;
            }
            set
            {
                this._serverName = value;
            }
        }
        public string DatabaseName
        {
            get
            {
                return this._datebaseName;
            }
            set
            {
                this._datebaseName = value;
            }
        }
        public string UserId
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }
        public bool IntegratedSecurity
        {
            get
            {
                return this._integratedSecurity;
            }
            set
            {
                this._integratedSecurity = value;
            }
        }
        public bool DataSourceToAllReports
        {
            get
            {
                return this._assignDataSourceAllReports;
            }
            set
            {
                this._assignDataSourceAllReports = value;
            }
        }
        public string SQLQuery
        {
            get
            {
                return this._sqlQuery;
            }
            set
            {
                this._sqlQuery = value;
            }
        }
        public static string ExportFilter
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Adobe Acrobat (*.pdf)|*.pdf|");
                stringBuilder.Append("Microsoft Excel 97-2000 (*.xls)|*.xls|");
                stringBuilder.Append("Microsoft Word (*.doc)|*.doc|");
                stringBuilder.Append("Formato RTF (*.rtf)|*.rtf");
                return stringBuilder.ToString();
            }
        }
        private static ExportFormatType GetExportType(CrystalExportFormat exportFormat)
        {
            ExportFormatType result;
            switch (exportFormat)
            {
                case CrystalExportFormat.Word:
                    result = ExportFormatType.WordForWindows;
                    break;
                case CrystalExportFormat.Excel:
                    result = ExportFormatType.Excel;
                    break;
                case CrystalExportFormat.RichText:
                    result = ExportFormatType.RichText;
                    break;
                case CrystalExportFormat.PortableDocFormat:
                    result = ExportFormatType.PortableDocFormat;
                    break;
                default:
                    throw new CrystalConnectorException(string.Format(CultureInfo.CurrentUICulture, "Unsupported export format '{0}'.", new object[]
				{
					exportFormat.ToString()
				}));
            }
            return result;
        }
        [SuppressMessage("Microsoft.Performance", "CA1807:AvoidUnnecessaryStringCreation", MessageId = "stack0")]
        private static CrystalExportFormat GetExportFormat(string fileName)
        {
            string text =  Helpers.FileExtension(fileName).ToUpper(CultureInfo.CurrentCulture);
            string text2 = text;
            if (text2 != null)
            {
                CrystalExportFormat result;
                if (!(text2 == "DOC"))
                {
                    if (!(text2 == "XLS"))
                    {
                        if (!(text2 == "RTF"))
                        {
                            if (!(text2 == "PDF"))
                            {
                                goto IL_5F;
                            }
                            result = CrystalExportFormat.PortableDocFormat;
                        }
                        else
                        {
                            result = CrystalExportFormat.RichText;
                        }
                    }
                    else
                    {
                        result = CrystalExportFormat.Excel;
                    }
                }
                else
                {
                    result = CrystalExportFormat.Word;
                }
                return result;
            }
        IL_5F:
            throw new CrystalConnectorException(string.Format(CultureInfo.CurrentUICulture, "Unsupported export format for file '{0}'.", new object[]
			{
				fileName
			}));
        }
        private static void AssignTableConnection(Table table, ConnectionInfo connection)
        {
            TableLogOnInfo logOnInfo = table.LogOnInfo;
            logOnInfo.ConnectionInfo = connection;
            table.ApplyLogOnInfo(logOnInfo);
        }
        private void AssignConnection()
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = this._datebaseName;
            connectionInfo.ServerName = this._serverName;
            if (this._integratedSecurity)
            {
                connectionInfo.IntegratedSecurity = this._integratedSecurity;
            }
            else
            {
                connectionInfo.UserID = this._userId;
                connectionInfo.Password = this._password;
            }
            foreach (Table table in this._reportDocument.Database.Tables)
            {
                CrystalConnector.AssignTableConnection(table, connectionInfo);
            }
            foreach (Section section in this._reportDocument.ReportDefinition.Sections)
            {
                foreach (ReportObject reportObject in section.ReportObjects)
                {
                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subreportObject = (SubreportObject)reportObject;
                        ReportDocument reportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);
                        foreach (Table table in reportDocument.Database.Tables)
                        {
                            CrystalConnector.AssignTableConnection(table, connectionInfo);
                        }
                    }
                }
            }
        }
        private void AssignDataSet()
        {
            DataSet dataSet = this._reportData.Copy();
            foreach (DataTable dataTable in dataSet.Tables)
            {
                DataColumn[] primaryKey = dataTable.PrimaryKey;
                for (int i = 0; i < primaryKey.Length; i++)
                {
                    DataColumn dataColumn = primaryKey[i];
                    dataColumn.AutoIncrement = false;
                }
                dataTable.PrimaryKey = null;
            }
            this._reportDocument.SetDataSource(dataSet);
            foreach (Section section in this._reportDocument.ReportDefinition.Sections)
            {
                foreach (ReportObject reportObject in section.ReportObjects)
                {
                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subreportObject = (SubreportObject)reportObject;
                        ReportDocument reportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);
                        reportDocument.SetDataSource(dataSet);
                    }
                }
            }
            dataSet.Dispose();
        }
        private void AssignDataSetConnection()
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = this._datebaseName;
            connectionInfo.ServerName = this._serverName;
            if (this._integratedSecurity)
            {
                connectionInfo.IntegratedSecurity = this._integratedSecurity;
            }
            else
            {
                connectionInfo.UserID = this._userId;
                connectionInfo.Password = this._password;
            }
            foreach (Table table in this._reportDocument.Database.Tables)
            {
                CrystalConnector.AssignTableConnection(table, connectionInfo);
            }
            using (DataSet dataSet = new DataSet())
            {
                using (SqlConnection connection = this.GetConnection())
                {
                  SqlHelper.FillDataset(connection, CommandType.Text, this._sqlQuery, dataSet, new string[]
					{
						this._reportDocument.Database.Tables[0].Name
					});
                }
                this.DataSource = dataSet;
            }
            using (DataSet dataSet2 = this._reportData.Copy())
            {
                this._reportDocument.SetDataSource(dataSet2);
            }
            foreach (Section section in this._reportDocument.ReportDefinition.Sections)
            {
                foreach (ReportObject reportObject in section.ReportObjects)
                {
                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subreportObject = (SubreportObject)reportObject;
                        ReportDocument reportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);
                        foreach (Table table in reportDocument.Database.Tables)
                        {
                            CrystalConnector.AssignTableConnection(table, connectionInfo);
                        }
                    }
                }
            }
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(string.Concat(new string[]
			{
				"Server=",
				this._serverName,
				";Database=",
				this._datebaseName,
				";UID=",
				this._userId,
				";pwd=",
				this._password
			}));
        }
        private ReportDocument CreateReportDocument(string reportFile)
        {
            ReportDocument reportDocument = new ReportDocument();
            this._reportFile = reportFile;
            reportDocument.Load(reportFile);
            return reportDocument;
        }
        private void SetParameters()
        {
            foreach (ParameterFieldDefinition parameterFieldDefinition in this._reportDocument.DataDefinition.ParameterFields)
            {
                try
                {
                    ParameterValues currentValues = parameterFieldDefinition.CurrentValues;
                    currentValues.Clear();
                    ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
                    if (this._parameters.ContainsKey(parameterFieldDefinition.Name))
                    {
                        parameterDiscreteValue.Value = this._parameters[parameterFieldDefinition.Name];
                    }
                    currentValues.Add(parameterDiscreteValue);
                    parameterFieldDefinition.ApplyCurrentValues(currentValues);
                }
                catch
                {
                }
            }
        }
        private void SetFormulas()
        {
            foreach (FormulaFieldDefinition formulaFieldDefinition in this._reportDocument.DataDefinition.FormulaFields)
            {
                try
                {
                    if (this._formulas.ContainsKey(formulaFieldDefinition.Name))
                    {
                        string text = formulaFieldDefinition.Text;
                        string text2 = this._formulas[formulaFieldDefinition.Name].ToString();
                        string text3 = "";
                        formulaFieldDefinition.Text = this._formulas[formulaFieldDefinition.Name].ToString();
                        if (!formulaFieldDefinition.Check(ref text3))
                        {
                            formulaFieldDefinition.Text = text;
                        }
                        else
                        {
                            formulaFieldDefinition.Text = text2;
                        }
                    }
                }
                catch
                {
                }
            }
        }
        private void SetRecordSelections()
        {
            if (this._recordSelection.Length > 0)
            {
                this._reportDocument.DataDefinition.RecordSelectionFormula = this._recordSelection;
            }
        }
        public CrystalConnector()
        {
            this._recordSelection = "";
            this._sqlQuery = "";
            this._parameters = new SortedList<string, object>();
            this._formulas = new SortedList<string, object>();
        }
        public CrystalConnector(ReportDocument report)
            : this()
        {
            this._reportDocument = report;
        }
        public CrystalConnector(string reportFile)
            : this()
        {
            this._reportDocument = this.CreateReportDocument(reportFile);
        }
        public CrystalConnector(ReportDocument report, string serverName, string databaseName, string userId, string userPassword)
            : this()
        {
            this._reportDocument = report;
            this._serverName = serverName;
            this._datebaseName = databaseName;
            this._userId = userId;
            this._password = userPassword;
        }
        public CrystalConnector(ReportDocument report, string serverName, string databaseName, bool integratedSecurity)
            : this()
        {
            this._reportDocument = report;
            this._serverName = serverName;
            this._datebaseName = databaseName;
            this._integratedSecurity = integratedSecurity;
        }
        public CrystalConnector(string reportFile, string serverName, string databaseName, string userId, string userPassword)
            : this()
        {
            this._reportDocument = this.CreateReportDocument(reportFile);
            this._serverName = serverName;
            this._datebaseName = databaseName;
            this._userId = userId;
            this._password = userPassword;
        }
        public CrystalConnector(string reportFile, string serverName, string databaseName, bool integratedSecurity)
            : this()
        {
            this._reportDocument = this.CreateReportDocument(reportFile);
            this._serverName = serverName;
            this._datebaseName = databaseName;
            this._integratedSecurity = integratedSecurity;
        }
        public void SetParameter(string name, object value)
        {
            if (this._parameters.ContainsKey(name))
            {
                this._parameters[name] = value;
            }
            else
            {
                this._parameters.Add(name, value);
            }
        }
        public void Close()
        {
            if (!this._reportIsOpen)
            {
                throw new InvalidOperationException("The report is already closed.");
            }
            if (this._reportIsOpen)
            {
                this._reportDocument.Close();
            }
            if (this._reportDocument != null)
            {
                this._reportDocument.Dispose();
                this._reportDocument = null;
            }
            if (this._reportData != null)
            {
                this._reportData.Dispose();
                this._reportData = null;
            }
            this._reportIsOpen = false;
        }
        public void Open()
        {
            if (this._reportDocument == null)
            {
                throw new CrystalConnectorException("First assign a report document.");
            }
            if (this._reportIsOpen)
            {
                throw new InvalidOperationException("The report is already open.");
            }
            this.SetParameters();
            this.SetFormulas();
            this.SetRecordSelections();
            if (this._reportData != null)
            {
                if (!this._assignDataSourceAllReports)
                {
                    this.AssignDataSet();
                }
                else
                {
                    if (this._serverName.Length == 0 || (!this._integratedSecurity && this._userId.Length == 0) || this._datebaseName.Length == 0)
                    {
                        throw new CrystalConnectorException("Connection information is incomplete. Report could not be opened.");
                    }
                    this.AssignDataSetConnection();
                }
            }
            else
            {
                if (this._sqlQuery.Length > 0)
                {
                    if (this._serverName.Length == 0 || (!this._integratedSecurity && this._userId.Length == 0) || this._datebaseName.Length == 0)
                    {
                        throw new CrystalConnectorException("Connection information is incomplete. Report could not be opened.");
                    }
                    this.AssignDataSetConnection();
                }
                else
                {
                    if (this._serverName.Length == 0 || (!this._integratedSecurity && this._userId.Length == 0) || this._datebaseName.Length == 0)
                    {
                        throw new CrystalConnectorException("Connection information is incomplete. Report could not be opened.");
                    }
                    this.AssignConnection();
                }
            }
            this._reportIsOpen = true;
        }
        public void Refresh()
        {
            if (!this._reportIsOpen)
            {
                throw new InvalidOperationException("The report is not open.");
            }
            this._reportDocument.Refresh();
        }
        public void Print(string printerName, int nrCopies, bool collatePages, int firstPage, int lastPage)
        {
            bool flag = false;
            if (!this._reportIsOpen)
            {
                this.Open();
                flag = true;
            }
            this._reportDocument.PrintOptions.PrinterName = printerName;
            if (firstPage < 1)
            {
                firstPage = 0;
            }
            if (lastPage < 1 || lastPage > 9999)
            {
                lastPage = 0;
            }
            this._reportDocument.PrintToPrinter(nrCopies, collatePages, firstPage, lastPage);
            if (flag)
            {
                this.Close();
            }
        }
        public void Print()
        {
            this.Print(string.Empty, 1, false, 0, 0);
        }
        public void Export(string fileName)
        {
            this.Export(fileName, CrystalConnector.GetExportFormat(fileName));
        }
        public void Export(IWin32Window owner)
        {
            if (!this._reportIsOpen)
            {
                throw new InvalidOperationException("The report is not open.");
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Exportar informe";
            saveFileDialog.Filter = CrystalConnector.ExportFilter;
            if (saveFileDialog.ShowDialog(owner) == DialogResult.OK)
            {
                this.Export(saveFileDialog.FileName);
            }
        }
        public void Export(string fileName, CrystalExportFormat exportFormat)
        {
            bool flag = false;
            if (!this._reportIsOpen)
            {
                this.Open();
                flag = true;
            }
            this._reportDocument.ExportToDisk(CrystalConnector.GetExportType(exportFormat), fileName);
            if (flag)
            {
                this.Close();
            }
        }
        public void Export(HttpResponse response, CrystalExportFormat exportFormat)
        {
            this.Export(response, exportFormat, false, "");
        }
        public void Export(HttpResponse response, CrystalExportFormat exportFormat, bool asAttachment, string attachmentName)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }
            if (attachmentName == null)
            {
                throw new ArgumentNullException("asAttachment");
            }
            bool flag = false;
            try
            {
                if (!this._reportIsOpen)
                {
                    this.Open();
                    flag = true;
                }
                this._reportDocument.ExportToHttpResponse(CrystalConnector.GetExportType(exportFormat), response, asAttachment, attachmentName);
            }
            finally
            {
                if (flag)
                {
                    this.Close();
                }
            }
        }
        public void SetRecordSelection(string selectionQuery)
        {
            this._recordSelection = selectionQuery;
        }
        public void SetFormula(string name, object value)
        {
            if (this._formulas.ContainsKey(name))
            {
                this._formulas[name] = value;
            }
            else
            {
                this._formulas.Add(name, value);
            }
        }
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void ViewerStatusBar(CrystalReportViewer viewer, bool visible)
        {
            if (viewer == null)
            {
                throw new ArgumentNullException("viewer");
            }
            foreach (Control control in viewer.Controls)
            {
                if (string.Compare(control.GetType().Name, "StatusBar", true, CultureInfo.InvariantCulture) == 0)
                {
                    control.Visible = visible;
                }
            }
        }
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void ViewerTabs(CrystalReportViewer viewer, bool visible)
        {
            if (viewer == null)
            {
                throw new ArgumentNullException("viewer");
            }
            foreach (Control control in viewer.Controls)
            {
                if (string.Compare(control.GetType().Name, "PageView", true, CultureInfo.InvariantCulture) == 0)
                {
                    TabControl tabControl = (TabControl)((PageView)control).Controls[0];
                    if (!visible)
                    {
                        tabControl.ItemSize = new Size(0, 1);
                        tabControl.SizeMode = TabSizeMode.Fixed;
                        tabControl.Appearance = TabAppearance.Buttons;
                    }
                    else
                    {
                        tabControl.ItemSize = new Size(67, 18);
                        tabControl.SizeMode = TabSizeMode.Normal;
                        tabControl.Appearance = TabAppearance.Normal;
                    }
                }
            }
        }
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void ReplaceReportName(CrystalReportViewer viewer, string oldName, string newName)
        {
            if (viewer == null)
            {
                throw new ArgumentNullException("viewer");
            }
            if (oldName == null || oldName.Length == 0)
            {
                throw new ArgumentException("May not be empty.", "oldName");
            }
            foreach (Control control in viewer.Controls)
            {
                if (string.Compare(control.GetType().Name, "PageView", true, CultureInfo.InvariantCulture) == 0)
                {
                    foreach (Control control2 in control.Controls)
                    {
                        if (string.Compare(control2.GetType().Name, "TabControl", true, CultureInfo.InvariantCulture) == 0)
                        {
                            TabControl tabControl = (TabControl)control2;
                            foreach (TabPage tabPage in tabControl.TabPages)
                            {
                                if (string.Compare(tabPage.Text, oldName, false, CultureInfo.InvariantCulture) == 0)
                                {
                                    tabPage.Text = newName;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._reportIsOpen)
                {
                    this._reportDocument.Close();
                }
                if (this._reportDocument != null)
                {
                    this._reportDocument.Dispose();
                    this._reportDocument = null;
                }
                if (this._reportData != null)
                {
                    this._reportData.Dispose();
                    this._reportData = null;
                }
            }
        }
    }
}
