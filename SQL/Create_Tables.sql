Create table Dish(
    id int not null auto_increment,
    name varchar(32),
    descr varchar(255),
    price decimal(7,2),
    primary key(id)
    );

Create table Beverage(
    id int not null auto_increment,
    name varchar(32),
    descr varchar(255),
    price decimal(7,2),
    primary key(id)
    );	
	
Create table Employee(
    id int not null auto_increment,
    firstName varchar(32),
    lastName varchar(32),
    primary key(id)
    );	
Create table OrderData(
    id int not null auto_increment,
    employeeId int,
    dishId int,
    beverageId int,
    orderDate date,
    primary key(id),
    foreign key (employeeId) references Employee(id),
    foreign key (dishId) references Dish(id),
    foreign key (beverageId) references Beverage(id)
    );	