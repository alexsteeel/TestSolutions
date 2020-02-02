-- Тестовое задание № 1.
-- MS SQL Server.

-- Подзадача 1.1.
-- Нахождение медианы для множества уникальных значений.

IF OBJECT_ID('tempdb.dbo.#UniqueValues') IS NOT NULL
    DROP TABLE #UniqueValues;

CREATE TABLE #UniqueValues
(
    ID INT PRIMARY KEY,
    [Value] INT NOT NULL UNIQUE
);

INSERT INTO #UniqueValues
(
    ID,
    [Value]
)
VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 10),
    (5, 200),
    (6, 800),
    (7, 1000);

SELECT
    a.[Value],
    COUNT(a.[Value]) AS [Count]
FROM
    #UniqueValues AS a
CROSS JOIN
    #UniqueValues AS b
GROUP BY
    a.[Value]
HAVING
    COUNT(CASE 
            WHEN a.[Value] <= b.[Value]
            THEN 1
            ELSE NULL
          END) = (COUNT(a.[Value]) + 1) / 2;

-- Подзадача 1.2.
-- Нахождение медианы для множества неуникальных значений.

-- Решение аналогично найденному в предыдущей задаче.
IF OBJECT_ID('tempdb.dbo.#NotUniqueValues') IS NOT NULL
    DROP TABLE #NotUniqueValues;

CREATE TABLE #NotUniqueValues
(
    ID INT PRIMARY KEY,
    [Value] INT NOT NULL
);

INSERT INTO #NotUniqueValues
(
    ID,
    [Value]
)
VALUES
    (1, 1),
    (2, 2),
    (3, 2),
    (4, 3),
    (5, 10),
    (6, 200),
    (7, 200),
    (8, 800),
    (9, 1000);

SELECT
    a.[Value],
    COUNT(a.[Value]) AS [Count]
FROM
    #NotUniqueValues AS a
CROSS JOIN
    #NotUniqueValues AS b
GROUP BY
    a.[Value]
HAVING
    COUNT(CASE 
            WHEN a.[Value] <= b.[Value]
            THEN 1
            ELSE NULL
          END) = (COUNT(a.[Value]) + 1) / 2;