SELECT     TOP (100) PERCENT dbo.SteCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja, dbo.SclFichaNotificacionCredito.dFechaUltimaCuota, 
                      dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion, dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID
FROM         dbo.SclFichaNotificacionDetalle INNER JOIN
                      dbo.SclFichaNotificacionCredito ON 
                      dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN
                      dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN
                      dbo.SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN
                      dbo.SclGrupoSolidario ON dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID AND 
                      dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN
                      dbo.SclSocia ON dbo.SclGrupoSocia.nSclSociaID = dbo.SclSocia.nSclSociaID INNER JOIN
                      dbo.SteCaja ON dbo.SclFichaNotificacionCredito.nStbPersonaLugarPagosID = dbo.SteCaja.nStbPersonaLugarPagosID INNER JOIN
                      dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID
WHERE     (dbo.SteCaja.nSteCajaID = 104) AND (dbo.StbValorCatalogo.sCodigoInterno = '5')
ORDER BY dbo.SclFichaNotificacionCredito.dFechaUltimaCuota