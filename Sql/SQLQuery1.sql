use demo;

/* TASK 2 */
CREATE TABLE users (
  id INT PRIMARY KEY NOT NULL,
  first_name VARCHAR(50),
  last_name VARCHAR(50),
  date_of_birth DATE,
  age INT,
  gender VARCHAR(10),
  phone_number VARCHAR(20),
  email VARCHAR(100),
  [address] VARCHAR(100),
  [state] VARCHAR(50),
  city VARCHAR(50),
  username VARCHAR(50),
  [password] VARCHAR(100)
);
INSERT INTO users (id,first_name, last_name, date_of_birth, age, gender, phone_number, email, [address], [state], city, username, [password])
VALUES (1,'Abin', 'John', '1990-05-15', 33, 'Male', '1234567890', 'abinjohn@example.com', '123 Main Street', 'California', 'Los Angeles', 'abinjohn', 'mypassword');
INSERT INTO users (id,first_name, last_name, date_of_birth, age, gender, phone_number, email, address, state, city, username, password)
VALUES (2,'John', 'Doe', '1998-05-15', 39, 'Male', '4567890123', 'john@example.com', 'abc Main St', 'California', 'Los Angeles', 'johndoe', 'newpassword');
INSERT INTO users (id, first_name, last_name, date_of_birth, age, gender, phone_number, email, [address], [state], city, username, [password])
VALUES 
  (3, 'Emily', 'Smith', '1995-02-20', 28, 'Female', '9876543210', 'emilysmith@example.com', '456 Elm Street', 'New York', 'New York City', 'emilysmith', 'mypassword1'),
  (4, 'Alex', 'Johnson', '1992-09-10', 31, 'Male', '1239874560', 'alexjohnson@example.com', '789 Oak Avenue', 'Florida', 'Miami', 'alexjohnson', 'mypassword2'),
  (5, 'Sarah', 'Wilson', '1988-07-01', 35, 'Female', '6540129873', 'sarahwilson@example.com', '321 Pine Road', 'Texas', 'Austin', 'sarahwilson', 'mypassword3'),
  (6, 'Daniel', 'Brown', '1993-11-12', 28, 'Male', '7893214560', 'danielbrown@example.com', '654 Cedar Lane', 'California', 'San Francisco', 'danielbrown', 'mypassword4'),
  (7, 'Sophia', 'Lee', '1990-06-25', 31, 'Female', '0129876543', 'sophialee@example.com', '987 Walnut Drive', 'New York', 'Albany', 'sophialee', 'mypassword5'),
  (8, 'Matthew', 'Taylor', '1987-12-03', 34, 'Male', '4567890123', 'matthewtaylor@example.com', '741 Birch Street', 'Texas', 'Dallas', 'matthewtaylor', 'mypassword6'),
  (9, 'Olivia', 'Martinez', '1996-04-18', 27, 'Female', '9874560123', 'oliviamartinez@example.com', '852 Elm Avenue', 'Florida', 'Tampa', 'oliviamartinez', 'mypassword7'),
  (10, 'Jacob', 'Garcia', '1991-08-07', 32, 'Male', '1236547890', 'jacobgarcia@example.com', '369 Oak Lane', 'California', 'San Diego', 'jacobgarcia', 'mypassword8');

UPDATE users
SET email = 'abinjohn123@example.com'
WHERE id = 2;

UPDATE users SET first_name = 'Oliver Twist' WHERE id='9';


SELECT * FROM users
WHERE id = 9;

INSERT INTO users (id,first_name, last_name, date_of_birth, age, gender, phone_number, email, [address], [state], city, username, [password])
VALUES (3,'Ab', 'J', '1990-05-15', 35, 'Female', '1234567890', 'abinjohn@example.com', '123 Main Street', 'California', 'Los Angeles', 'abinjohn', 'mypassword');

DELETE FROM users WHERE id = 3;

SELECT * FROM users;

/* TASK 3 AND 6 */

CREATE TABLE employes (
  id INT PRIMARY KEY NOT NULL,
  first_name VARCHAR(50),
  last_name VARCHAR(50),
  age INT,
  gender VARCHAR(10),
  phone_number VARCHAR(20),
  employeeid INT FOREIGN KEY REFERENCES users(id),
  department VARCHAR(20),
  salary INT,
);

INSERT INTO employes (id,first_name,last_name,age,gender,phone_number,employeeid,department,salary)
VALUES (1,'qw','er',30,'Female',1234567890,2,'sales',12000)
INSERT INTO employes (id,first_name,last_name,age,gender,phone_number,employeeid,department,salary)
VALUES (2,'alex','john',31,'Male',6745321678,2,'backend',15000)
INSERT INTO employes (id,first_name,last_name,age,gender,phone_number,employeeid,department,salary)
VALUES (3,'anu','baby',28,'Female',9878908665,1,'frontend',20000)
INSERT INTO employes (id,first_name,last_name,age,gender,phone_number,employeeid,department,salary)
VALUES (4,'anju','baby',28,'Female',9878908665,1,'frontend',40000)
INSERT INTO employes (id, first_name, last_name, age, gender, phone_number, employeeid, department, salary)
VALUES
  (5, 'John', 'Doe', 30, 'Male', '123-456-7890', 4, 'IT', 5000),
  (6, 'Jane', 'Smith', 28, 'Female', '987-654-3210', 7, 'Sales', 6000),
  (7, 'Michael', 'Johnson', 35, 'Male', '555-555-5555',3, 'HR', 7000),
  (8, 'Emily', 'Davis', 32, 'Female', '111-222-3333', 8, 'IT', 5500),
  (9, 'David', 'Anderson', 40, 'Male', '444-444-4444', 9, 'Finance', 8000);

/*SELECT MAX(salary) AS [second_heighest_salary] FROM employes WHERE salary < ( SELECT MAX(salary) FROM employes)*/

SELECT TOP 2 salary
FROM employes
ORDER BY salary DESC

/*[second_heighest_salary*/
SELECT TOP 1 salary
FROM (
	  SELECT DISTINCT TOP 2 salary
	  FROM employes
	  ORDER BY salary DESC
	  ) RESULT
ORDER BY salary

SELECT MAX(salary) FROM employes

SELECT COUNT(*) AS sales_employees
FROM employes
WHERE employes.department = 'sales';

SELECT COUNT(*) AS frontend_employees
FROM employes
WHERE employes.department = 'frontend';

SELECT * FROM users WHERE age=33;

SELECT * FROM users ORDER BY first_name DESC;

SELECT * FROM users WHERE first_name LIKE 'a%';

SELECT * FROM employes WHERE age BETWEEN 20 AND 30;

/* JOINS */

SELECT employes.id, employes.first_name, employes.last_name, employes.age, employes.gender, employes.phone_number, users.email, users.[address], users.[state], users.city, users.username
FROM employes 
INNER JOIN users 
ON employes.employeeid = users.id;

SELECT e.id, e.first_name, e.last_name, u.email
FROM employes AS e
LEFT JOIN users AS u ON e.employeeid = u.id;

SELECT e.id, e.first_name, e.last_name, u.email
FROM employes AS e
RIGHT JOIN users AS u ON e.employeeid = u.id;


SELECT e.id, e.first_name, e.last_name, u.email
FROM employes AS e
FULL OUTER JOIN users AS u ON e.employeeid = u.id;
