-- запит, що виводить назву регіону та максимальну кількість видобутку за день
CREATE TEMP TABLE temp_production AS
(SELECT *
FROM production);
SELECT r.name_region, MAX(p.production_per_day) AS max_production
FROM temp_production AS p
LEFT JOIN region AS r USING (id_region)
GROUP BY name_region
ORDER BY max_production DESC;

DROP TABLE temp_production;

-- запит, що об'єднює дві таблиці, сортує їх за назвою родовища та показує спочатку null значення
CREATE TEMP TABLE temp_production AS
(SELECT *
FROM production);
INSERT INTO temp_production(id_region, id_state, id_deposit, date_of_data_submission, production_per_day) VALUES (5, 4, 22, '2020-09-09', 38294);
SELECT d.name_deposit, p.date_of_data_submission
FROM temp_production AS p
LEFT JOIN deposit d USING (id_deposit)
ORDER BY d.name_deposit NULLS FIRST;

-- запит, що відображає нафтові родовища
SELECT name_deposit, address_deposit
FROM deposit
WHERE name_deposit LIKE '%Н'
ORDER BY name_deposit;

DROP TABLE temp_production;

-- запит, що виводить назву регіону та різницю між першою і останньою подачею інформації про їх видобуток
CREATE TEMP TABLE temp_production AS
(SELECT *
FROM production);
SELECT r.name_region, AGE(MAX(p.date_of_data_submission), MIN(p.date_of_data_submission)) AS between_min_and_max
FROM temp_production AS p
INNER JOIN region AS r USING (id_region)
GROUP BY name_region
ORDER BY between_min_and_max DESC;

-- виводить назви родовища, де рік введення в експлуатацію раніший за 2010
SELECT EXTRACT(YEARS FROM p.date_of_data_submission) AS year, (SELECT name_deposit FROM deposit
WHERE id_deposit = p.id_deposit)
FROM production AS p
WHERE EXTRACT(YEARS FROM p.date_of_data_submission) < 2010;

-- запит, що виводить роки, коли поступали дані про першу область
SELECT DISTINCT date_part('year',date_of_data_submission) AS year
FROM production
WHERE id_state = 1
ORDER BY year;

-- запит, що виводить назву родовища та термні, коли було введено у експлуатацію
SELECT name_deposit, CASE WHEN year_of_commissioning > 2019 THEN 'нещодавно'
WHEN year_of_commissioning > 2012 THEN 'до 10 років'
ELSE 'давно' END AS commissioning
FROM deposit
ORDER BY name_deposit;

-- функція, що виводить список родовищ, які мають кількість свердловин, що перевищує вказану
CREATE OR REPLACE FUNCTION more_number_of_wells_deposits (amount INTEGER)
RETURNS TABLE(name_deposit varchar(30), number_of_wells integer) AS $$
BEGIN
RETURN QUERY
(SELECT deposit.name_deposit, deposit.number_of_wells
FROM deposit
WHERE deposit.number_of_wells > amount
ORDER BY deposit.number_of_wells DESC);
END;
$$ LANGUAGE 'plpgsql';

-- виклик функції
SELECT * FROM more_number_of_wells_deposits(40);

-- використання курсору для формування звіту
CREATE OR REPLACE FUNCTION kursor()
RETURNS TEXT AS $$
DECLARE
period1 deposit.name_deposit % TYPE;
period2 deposit.name_deposit % TYPE;
period3 deposit.name_deposit % TYPE;
global_text TEXT;
kursor CURSOR FOR
SELECT (CASE
WHEN temp_table.year_of_commissioning < 2010 THEN temp_table.name_deposit
ELSE repeat(' ', 28) END) AS "-2010",
(CASE WHEN temp_table.year_of_commissioning BETWEEN 2010 AND 2015 THEN temp_table.name_deposit
ELSE repeat(' ', 28) END) AS "2010-2015",
(CASE WHEN temp_table.year_of_commissioning BETWEEN 2016 AND EXTRACT(YEAR FROM CURRENT_DATE) THEN temp_table.name_deposit
ELSE repeat(' ', 28) END) AS "2015+"
FROM (SELECT name_deposit, year_of_commissioning
FROM deposit) AS temp_table
ORDER BY name_deposit;
BEGIN
global_text := repeat(' ', 10) || 'Звіт про динаміку введення родовищ' || E'\n' || repeat(' ', 14) || 'в експлуатацію станом на ' || to_char(EXTRACT(YEAR FROM CURRENT_DATE), '9999') || E'\n' || E'\n' || '-2010' || repeat(' ', 22) || '2010-2015' || repeat(' ', 20) || '2015+' || E'\n';
OPEN kursor;
LOOP
FETCH kursor INTO period1, period2, period3;
EXIT WHEN NOT FOUND;
global_text := global_text || period1 || period2 || period3 || E'\n';
END LOOP;
CLOSE kursor;
RETURN global_text;
END;
$$ LANGUAGE 'plpgsql';

SELECT kursor() AS "Облік свердловин";
