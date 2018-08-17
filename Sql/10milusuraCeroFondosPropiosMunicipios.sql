SELECT     Departamento, Municipio, COUNT(nSclFichaNotificacionDetalleID) AS TotalSocias
FROM         (SELECT     TOP (100) PERCENT dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion, 
                                              dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado, dbo.vwStbUbicacionGeografica.Departamento, 
                                              dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.Distrito, dbo.vwStbUbicacionGeografica.Barrio, 
                                              dbo.SclSocia.sNombre1, dbo.SclSocia.sNombre2, dbo.SclSocia.sApellido1, dbo.SclSocia.sApellido2, dbo.SclSocia.sNumeroCedula, 
                                              dbo.SclGrupoSolidario.sCodigo, dbo.SclGrupoSolidario.sDescripcion AS Expr1, 
                                              dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID, dbo.SccSolicitudCheque.nSccSolicitudChequeID, 
                                              dbo.SclFichaNotificacionCredito.dFechaPrimerCuota, dbo.SclTipodePlandeNegocio.nCodigo, StbValorCatalogo_1.sCodigoInterno AS Expr2, 
                                              StbValorCatalogo_1.sDescripcion AS Expr3, dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID, 
                                              dbo.ScnFuenteFinanciamiento.sCodigo AS Expr4, dbo.ScnFuenteFinanciamiento.sNombre
                       FROM          dbo.SccSolicitudDesembolsoCredito INNER JOIN
                                              dbo.SclFichaNotificacionDetalle ON 
                                              dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID INNER
                                               JOIN
                                              dbo.SclFichaNotificacionCredito ON 
                                              dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN
                                              dbo.SclGrupoSolidario ON dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN
                                              dbo.SclGrupoSocia ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioID INNER JOIN
                                              dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID AND 
                                              dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID INNER JOIN
                                              dbo.SclSocia ON dbo.SclGrupoSocia.nSclSociaID = dbo.SclSocia.nSclSociaID INNER JOIN
                                              dbo.StbValorCatalogo ON dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN
                                              dbo.vwStbUbicacionGeografica ON dbo.SclGrupoSolidario.nStbBarrioVerificadoID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER JOIN
                                              dbo.SccSolicitudCheque ON 
                                              dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER
                                               JOIN
                                              dbo.SclTipodePlandeNegocio ON 
                                              dbo.SclGrupoSolidario.nSclTipodePlandeNegocioID = dbo.SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN
                                              dbo.StbValorCatalogo AS StbValorCatalogo_1 ON 
                                              dbo.SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo_1.nStbValorCatalogoID INNER JOIN
                                              dbo.ScnFuenteFinanciamiento ON 
                                              dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID
                       WHERE      (dbo.StbValorCatalogo.sCodigoInterno = '2') AND (dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado = 10000) AND 
                                              (dbo.SclTipodePlandeNegocio.nCodigo = 1 OR
                                              dbo.SclTipodePlandeNegocio.nCodigo = 2) AND (dbo.ScnFuenteFinanciamiento.sCodigo <> '93')
                       ORDER BY dbo.SclFichaNotificacionCredito.dFechaPrimerCuota DESC) AS lista
GROUP BY Departamento, Municipio

Order by 1,2