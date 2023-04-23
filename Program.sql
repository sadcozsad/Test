/* 1 */
SELECT *
FROM Employee
ORDER BY Salary DESC
limit 1

/* 2 */
WITH RECURSIVE bfs(id, chief_id, lvl) AS (
    SELECT id, chief_id, 1
    FROM employee 
	WHERE chief_id IS NULL
    UNION ALL
    SELECT employee.id, employee.chief_id, lvl + 1
    FROM employee INNER JOIN bfs ON bfs.id = employee.chief_id
)
SELECT lvl
FROM bfs 
ORDER BY lvl DESC
limit 1

/* 3 */
SELECT sum(salary), department_id
FROM employee
GROUP BY department_id
ORDER BY sum DESC
limit 1


/* 4 */
SELECT *
FROM Employee
WHERE Name LIKE 'Р%н'
