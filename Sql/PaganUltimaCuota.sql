SELECT     nSccReciboOficialCajaID, nSccSolicitudChequeID, nStbEstadoReciboID, nCodigo, dFechaRecibo, nValor, sConceptoPago, sMotivoAnulacion, 
                      nSrhEmpleadoCajeroID, nSteMinutaDepositoID, nAplicado, nSteCajaID, nManual, nStbDepartamentoID, nSccRegistroDenominacionID, nCancelado, 
                      nCodigoTalonario, nUsuarioCreacionID, dFechaCreacion, nUsuarioModificacionID, dFechaModificacion, nSccReciboOficialCajaIDLocal, NoEnvio, 
                      nSteCajaIDLocal, EnvioNumero, sMotivoAnulacionConfirmaCentral, nTieneConflictoEnCentral, nNumeroCuota, nNumCuota
FROM         (SELECT     TOP (100) PERCENT dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaID, dbo.SttLocalSccReciboOficialCaja.nSccSolicitudChequeID, 
                                              dbo.SttLocalSccReciboOficialCaja.nStbEstadoReciboID, dbo.SttLocalSccReciboOficialCaja.nCodigo, 
                                              dbo.SttLocalSccReciboOficialCaja.dFechaRecibo, dbo.SttLocalSccReciboOficialCaja.nValor, 
                                              dbo.SttLocalSccReciboOficialCaja.sConceptoPago, dbo.SttLocalSccReciboOficialCaja.sMotivoAnulacion, 
                                              dbo.SttLocalSccReciboOficialCaja.nSrhEmpleadoCajeroID, dbo.SttLocalSccReciboOficialCaja.nSteMinutaDepositoID, 
                                              dbo.SttLocalSccReciboOficialCaja.nAplicado, dbo.SttLocalSccReciboOficialCaja.nSteCajaID, dbo.SttLocalSccReciboOficialCaja.nManual, 
                                              dbo.SttLocalSccReciboOficialCaja.nStbDepartamentoID, dbo.SttLocalSccReciboOficialCaja.nSccRegistroDenominacionID, 
                                              dbo.SttLocalSccReciboOficialCaja.nCancelado, dbo.SttLocalSccReciboOficialCaja.nCodigoTalonario, 
                                              dbo.SttLocalSccReciboOficialCaja.nUsuarioCreacionID, dbo.SttLocalSccReciboOficialCaja.dFechaCreacion, 
                                              dbo.SttLocalSccReciboOficialCaja.nUsuarioModificacionID, dbo.SttLocalSccReciboOficialCaja.dFechaModificacion, 
                                              dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaIDLocal, dbo.SttLocalSccReciboOficialCaja.NoEnvio, 
                                              dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.SttLocalSccReciboOficialCaja.EnvioNumero, 
                                              dbo.SttLocalSccReciboOficialCaja.sMotivoAnulacionConfirmaCentral, dbo.SttLocalSccReciboOficialCaja.nTieneConflictoEnCentral, 
                                              dbo.SttLocalSccTablaAmortizacionPagos.nNumeroCuota, SclFichaNotificacionDetalle_1.nNumCuota
                       FROM          dbo.SclFichaNotificacionDetalle INNER JOIN
                                              dbo.SclFichaNotificacionCredito ON 
                                              dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN
                                              dbo.SclGrupoSolidario ON dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN
                                              dbo.SclGrupoSocia ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioID INNER JOIN
                                              dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID AND 
                                              dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID INNER JOIN
                                              dbo.SccTablaAmortizacion ON 
                                              dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccTablaAmortizacion.nSclFichaNotificacionDetalleID INNER JOIN
                                              dbo.SttLocalSccReciboOficialCaja INNER JOIN
                                              dbo.SttLocalSccTablaAmortizacionPagos ON 
                                              dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaID = dbo.SttLocalSccTablaAmortizacionPagos.nSccReciboOficialCajaID INNER JOIN
                                              dbo.SccSolicitudCheque ON dbo.SttLocalSccReciboOficialCaja.nSccSolicitudChequeID = dbo.SccSolicitudCheque.nSccSolicitudChequeID ON 
                                              dbo.SccTablaAmortizacion.nSccTablaAmortizacionID = dbo.SttLocalSccTablaAmortizacionPagos.nSccTablaAmortizacionID INNER JOIN
                                                  (SELECT     nSclFichaNotificacionDetalleID, MAX(nNumCuota) AS nNumCuota
                                                    FROM          dbo.SccTablaAmortizacion AS SccTablaAmortizacion_1
                                                    GROUP BY nSclFichaNotificacionDetalleID) AS SclFichaNotificacionDetalle_1 ON 
                                              dbo.SccTablaAmortizacion.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle_1.nSclFichaNotificacionDetalleID
                       WHERE      (dbo.SttLocalSccReciboOficialCaja.nSteCajaID = 104) AND (dbo.SttLocalSccReciboOficialCaja.EnvioNumero = 79)
                       ORDER BY dbo.SttLocalSccTablaAmortizacionPagos.nNumeroCuota DESC) AS A
WHERE     (nNumeroCuota >= nNumCuota)