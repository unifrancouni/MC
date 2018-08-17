SELECT request_session_id sessionid,
 resource_type type,
 resource_database_id dbid,
 OBJECT_NAME(resource_associated_entity_id, resource_database_id) objectname,
 request_mode rmode,
 request_status rstatus
FROM sys.dm_tran_locks
WHERE resource_type IN ('DATABASE', 'OBJECT')