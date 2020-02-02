-- Тестовое задание № 1.
-- MS SQL Server.

-- Подзадача 1.3.
-- Нахождение количества потомков для узла иерархической структуры.

IF OBJECT_ID('tempdb.dbo.##Tree') IS NOT NULL
    DROP TABLE #Tree;

CREATE TABLE #Tree
(
    ID INT PRIMARY KEY,
    ParentID INT NULL REFERENCES #Tree (ID)
);

INSERT INTO #Tree
(
    ID,
    ParentID
)
VALUES
    (0, NULL),
    (1, 0),
    (2, 0),
    (3, 1),
    (4, 1);

WITH Rec AS 
(
    SELECT
        a.ID,
        ID as ID1
    FROM
        #Tree AS a
    UNION ALL
    SELECT
        b.ID,
        c.id
    FROM
        Rec AS b
    INNER JOIN
        #Tree AS c
        ON c.ParentID = b.ID1
)
SELECT
    a.ID, 
    COUNT(a.ID) AS SubtreeSize
FROM
    Rec AS a
GROUP BY
    a.ID;

