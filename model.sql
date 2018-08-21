CREATE DATABASE recruitment_test;

USE recruitment_test;

CREATE TABLE recruiter (id INT NOT NULL AUTO_INCREMENT,
			     				name VARCHAR(20),
	 							PRIMARY KEY (id));
	 							
CREATE TABLE interview (id INT NOT NULL AUTO_INCREMENT,
			     				type VARCHAR(20),
			     				id_recruiter INT NOT NULL,
	 							PRIMARY KEY (id),
	 							FOREIGN KEY (id_recruiter) REFERENCES recruiter(id) ON DELETE CASCADE);