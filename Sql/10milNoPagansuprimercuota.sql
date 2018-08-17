SELECT     nMontoCreditoAprobado, Departamento, Municipio, Distrito, Barrio, sNombre1, sNombre2, sApellido1, sApellido2, sNumeroCedula, sCodigo, 
                      dFechaPrimerCuota, nCodigo, nScnFuenteFinanciamientoID, sNombre, TieneAlmenosunRecibo
FROM         (SELECT     TOP (100) PERCENT dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion, 
                                              dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado, dbo.vwStbUbicacionGeografica.Departamento, 
                                              dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.Distrito, dbo.vwStbUbicacionGeografica.Barrio, 
                                              dbo.SclSocia.sNombre1, dbo.SclSocia.sNombre2, dbo.SclSocia.sApellido1, dbo.SclSocia.sApellido2, dbo.SclSocia.sNumeroCedula, 
                                              dbo.SclGrupoSolidario.sCodigo, dbo.SclGrupoSolidario.sDescripcion AS Expr1, 
                                              dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID, dbo.SccSolicitudCheque.nSccSolicitudChequeID, 
                                              dbo.SclFichaNotificacionCredito.dFechaPrimerCuota, dbo.SclTipodePlandeNegocio.nCodigo, StbValorCatalogo_1.sCodigoInterno AS Expr2, 
                                              StbValorCatalogo_1.sDescripcion AS Expr3, dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID, 
                                              dbo.ScnFuenteFinanciamiento.sCodigo AS Expr4, dbo.ScnFuenteFinanciamiento.sNombre, Recibo.nSccSolicitudChequeID AS Expr5, 
                                              CASE WHEN Recibo.nSccSolicitudChequeID IS NULL THEN 'NO' ELSE 'SI' END AS TieneAlmenosunRecibo
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
                                              dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID LEFT OUTER JOIN
                                                  (SELECT     SccSolicitudCheque_1.nSccSolicitudChequeID
                                                    FROM          dbo.SccReciboOficialCaja INNER JOIN
                                                                           dbo.SccSolicitudCheque AS SccSolicitudCheque_1 ON 
                                                                           dbo.SccReciboOficialCaja.nSccSolicitudChequeID = SccSolicitudCheque_1.nSccSolicitudChequeID INNER JOIN
                                                                           dbo.StbValorCatalogo AS StbValorCatalogo_2 ON 
                                                                           dbo.SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo_2.nStbValorCatalogoID
                                                    GROUP BY SccSolicitudCheque_1.nSccSolicitudChequeID, StbValorCatalogo_2.sCodigoInterno, StbValorCatalogo_2.sDescripcion
                                                    HAVING      (StbValorCatalogo_2.sCodigoInterno = '1') OR
                                                                           (StbValorCatalogo_2.sCodigoInterno = '2')) AS Recibo ON 
                                              dbo.SccSolicitudCheque.nSccSolicitudChequeID = Recibo.nSccSolicitudChequeID
                       WHERE      (dbo.StbValorCatalogo.sCodigoInterno = '2') AND (dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado = 10000) AND 
                                              (dbo.SclTipodePlandeNegocio.nCodigo = 1 OR
                                              dbo.SclTipodePlandeNegocio.nCodigo = 2) AND (dbo.ScnFuenteFinanciamiento.sCodigo = '10') AND 
                                              (dbo.SclFichaNotificacionCredito.dFechaPrimerCuota <= CONVERT(DATETIME, '2013-06-13 00:00:00', 102))
                       ORDER BY dbo.SclFichaNotificacionCredito.dFechaPrimerCuota DESC) AS Lista
WHERE     (TieneAlmenosunRecibo = 'NO')