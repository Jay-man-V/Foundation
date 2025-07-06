use [UnitTesting]
-- select * from log.EventLog order by Id desc;

select
--    root.CreatedOn,
    root.BatchName,
    root.ProcessName,
    root.TaskName,
    root.StartedOn,
    root.FinishedOn,

--    c1.CreatedOn,
--    c1.BatchName,
    c1.ProcessName,
    c1.TaskName,
    c1.StartedOn,
    c1.FinishedOn,
    c1.Information,

    null
from
    log.EventLog root
        inner join log.EventLog c1 ON
        (
            c1.ParentId = root.Id
        )
order by
    root.Id,
    c1.Id

-- delete from log.eventlog
