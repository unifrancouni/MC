Update dbo.SccSolicitudChequeDetalle
Set 

ndebito =CASE WHEN nDebito = 0 THEN 1 ELSE 0 END 
WHERE     (nSccSolicitudChequeDetalleID IN
                          (SELECT     SccSolicitudChequeDetalle_1.nSccSolicitudChequeDetalleID
                            FROM          dbo.SccSolicitudCheque INNER JOIN
                                                   dbo.SccSolicitudChequeDetalle AS SccSolicitudChequeDetalle_1 ON 
                                                   dbo.SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle_1.nSccSolicitudChequeID INNER JOIN
                                                   dbo.ScnFuenteFinanciamiento ON 
                                                   dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID INNER JOIN
                                                   dbo.ScnCatalogoContable ON 
                                                   SccSolicitudChequeDetalle_1.nScnCatalogoContableID = dbo.ScnCatalogoContable.nScnCatalogoContableID
                            WHERE      (dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID = 9)))