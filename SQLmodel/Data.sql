/*
SET IDENTITY_INSERT [Driver] ON 
SET IDENTITY_INSERT [FineType] ON 
SET IDENTITY_INSERT [Employee] ON  
SET IDENTITY_INSERT [Office] ON  
SET IDENTITY_INSERT [Vehicle] ON  
SET IDENTITY_INSERT [Record] ON  
SET IDENTITY_INSERT [LicenseGroup] ON  
*/

SET DATEFORMAT dmy

SET IDENTITY_INSERT [Driver] ON 
INSERT into [Driver] (ID, Name, Street, Town, Country, Residence, BirthDate, RemainingPoints, LicenseNumber, LicenseValidity, State, Password)
VALUES 
(1, 'Petr Matìj', 'Ulièní 111', 'Paskov', 'Èeská Republika', 'Èeské', '22.11.1994', 0, 154875, '10.6.2020', 1, 'pass'),
(2, 'Tomáš Nový', 'Ostravská 10', 'Frýdek-Místek', 'Èeská Republika', 'Èeské', '2.1.1993', 0, 444545, '10.10.2020', 1, 'pass'),
(3, 'Lukáš Vláèil', 'Brnìnská 1', 'Praha', 'Èeská Republika', 'Èeské', '5.11.1980', 3, 546545, '5.10.2005', 1, 'pass'),
(4, 'Jana Mikešová', 'Prašná 5', 'Ostrava', 'Èeská Republika', 'Èeské', '5.6.1990', 3, 786786, '10.5.2010', 1, 'pass'),
(5, 'Eliška Oboøilová', 'Místecká 55', 'Zlín', 'Èeská Republika', 'Èeské', '22.1.1989', 0, 456710, '6.1.2018', 1, 'pass'),
(6, 'Dagmar Horeèková', 'Anenská 11', 'Kladno', 'Èeská Republika', 'Èeské', '10.9.1950', 2, 567874, '10.10.2025', 1, 'pass'),
(7, 'Dalibor Novák', 'Anglická 1', 'Prostìjov', 'Èeská Republika', 'Èeské', '5.5.1965', 0, 542470, '7.2.2024', 1, 'pass'),
(8, 'Randeep Singh', 'Armádní 98', 'Brno', 'Èeská Republika', 'Indické', '21.10.1980', 1, 745767, '8.5.2021', 1, 'pass'),
(9, 'Chim Huu Dung', 'Barkhor', 'Peking', 'Èína', 'Èínské', '20.1.1990', 5, 754577, '2.2.2034', 1, 'pass'),
(10, 'Rajib Kumar', 'Gunlagadda', 'Dillí', 'Indie', 'Indické', '30.3.1996', 10, 567891, '3.3.2019', 1, 'pass'),
(11, 'Bartosz Adamczyk', 'Dìlnická 12', 'Opava', 'Èeská Republika', 'Polské', '1.1.1984', 11, 545210, '3.3.2020', 1, 'pass'),
(12, 'Juliusz Makowski', 'Miodowa 2', 'Katowice', 'Polsko', 'Polské', '2.10.1989', 5, 457785, '10.8.2021', 1, 'pass'),
(13, 'Dominik Grabowski', 'Stradomska 10', 'Krakow', 'Polsko', 'Èeské', '14.5.1975', 0, 678945, '5.7.2022', 1, 'pass'),
(14, 'Alexandr Smetana', 'Dlouhá 954', 'Kromìøíž', 'Èeská Republika', 'Èeské', '13.10.1967', 5, 451001, '15.1.2023', 1, 'pass'),
(15, 'Roman Dvoøák', 'Finská 54', 'Tøebíè', 'Èeská Republika', 'Èeské', '20.6.1992', 0, 754241, '30.10.2024', 1, 'pass'),
(16, 'Petr Horák', 'Gaussova 1', 'Znojmo', 'Èeská Republika', 'Èeské', '5.5.1995', 1, 457845, '30.11.2025', 1, 'pass'),
(17, 'Marek Pospíšil', 'Bassova 95', 'Písek', 'Èeská Republika', 'Èeské', '24.3.1970', 0, 457888, '12.12.2025', 1, 'pass'),
(18, 'Jiøí Kuèera', 'Batelovská 4', 'Strakonice', 'Èeská Republika', 'Èeské', '28.9.1985', 0, 412475, '11.10.2026', 1, 'pass'),
(19, 'Ozzy Osbourne', 'Victoria St', 'Aston', 'Anglie', 'Anglické', '3.12.1948', 11, 666666, '6.6.2026', 1, 'pass'),
(20, 'Iveta Veselá', 'Walton St', 'Londýn', 'Anglie', 'Èeské', '20.10.1990', 2, 1278777, '5.5.2020', 1, 'pass'),
(21, 'Iveta Mikešová', 'Hlavní tøída 5', 'Zlín', 'Èeská Republika', 'Èeské', '2.2.1992', 0, 475420, '5.1.2024', 1, 'pass'),
(22, 'admin', 'admin', 'admin', 'admin', 'admin', '22.11.1994', 10, 111, '20.10.2020', 1, 'admin');
SET IDENTITY_INSERT [Driver] OFF


SET IDENTITY_INSERT [LicenseGroup] ON 
INSERT into [LicenseGroup] (ID, "Group", Description)
VALUES 
(1, 'A', 'Motorky všech kategorií'),
(2, 'A1', 'Lehké motocykly do 125 ccm a výkonu nejvýše 11 kW'),
(3, 'A2', 'Motorky s výkonem maximálnì 35 kW'),
(4, 'B', 'Motorová vozidla do 3,5 tuny a maximálnì 8 míst k sezení'),
(5, 'B+E', 'LicenseGroup B + pøípojné vozidlo do 3,5 tuny'),
(6, 'B1', 'Tøíkolové a ètyøkolové vozidla'),
(7, 'C', 'Motorová vozidla pøevyšující 3,5 tuny a více než 8 míst k sezení'),
(8, 'C+E', 'LicenseGroup C + pøípojné vozidlo'),
(9, 'D', 'Vozidla pro pøepravu osob s více než 8 místy k sezení'),
(10, 'D+E', 'LicenseGroup D + pøípojné vozidlo'),
(11, 'D1', 'Vozidla pro pøepravu osob v více než 8 místy, ale ménì než 16 místy k sezení'),
(12, 'D1+E', 'LicenseGroup D1 + pøípojné vozidlo'),
(13, 'T', 'Traktory a pracovní stroje i s pøípojným vozidlem')
SET IDENTITY_INSERT [LicenseGroup] OFF


SET IDENTITY_INSERT [FineType] ON 
INSERT into [FineType] (ID, Category, Description, MaxFine, PointsPenalty, State)
VALUES 
(1, 'Jizda na cervenou', '', 2000, 2, 1),
(2, 'Nedani prednosti v jizde', '', 3000, 1, 1),
(3, 'Parkovani', 'Stání na nevyznaèeném místì, stání na místì vyhrazeném pro invalidy', 300, 0, 1),
(4, 'Rizeni bez dokladu', '', 1000, 1, 1),
(5, 'Rizeni pod vlivem omamnych latek', '', 20000, 3, 1),
(6, 'Rychlost', 'Pøekroèení rychlosti o 30km/h', 10000, 2, 1),
(7, 'Spatny stav vozidla', 'Øízení vozidla, které je technicky nezpùsobilé k provozu na pozemních komunikacích tak závažným zpùsobem, že bezprostøednì ohrožuje ostatní úèastníky provozu na pozemních komunikacích', 10000, 5, 1),
(8, 'Telefonovani za jizdy', '', 2000, 1, 1)
SET IDENTITY_INSERT [FineType] OFF


SET IDENTITY_INSERT [Office] ON 
INSERT into [Office] (ID, Street, Town, Country, Type, State)
VALUES 
(1, 'Radnièní 5', 'Ostrava', 'Èeská Republika', 'Krajske', 1),
(2, 'Hlavní tøída 10', 'Frýdek-Místek', 'Èeská Republika', 'Obvodni', 1),
(3, 'Ostravská 10', 'Ostrava', 'Èeská Republika', 'Reditelstvi', 1),
(4, 'U Parku 55', 'Praha', 'Èeská Republika', 'Reditelstvi', 1),
(5, 'Oboøilova 6', 'Praha', 'Èeská Republika', 'Obvodni', 1),
(6, 'Komenského 13', 'Praha', 'Èeská Republika', 'Mistni', 1),
(7, 'Frýdlantská 62', 'Ostrava', 'Èeská Republika', 'Mistni', 1),
(8, 'Janáèkova 955', 'Ostrava', 'Èeská Republika', 'Obvodni', 1)
SET IDENTITY_INSERT [Office] OFF


SET IDENTITY_INSERT [Vehicle] ON 
INSERT into [Vehicle] (ID, VIN, SPZ, Brand, Model, Type, Color, driverID, State)
VALUES 
(1, 'HDF484DF451D2FD33F', '3G5 4784', 'Škoda', 'Octavia', 'Osobní automobil', 'Modrá', 1, 1),
(2, 'DF1Q9K4J4H12HGH1G2', '6Q3 5478', 'Nissan', 'Navara', 'Terénní automobil', 'Èervená', 1, 1),
(3, 'WEER4H411V3VG44FG4', '6N9 3715', 'Iveco', 'Crossway', 'Autobus', 'Èerná', 2, 1),
(4, 'V1C3S6D5F4W8ER4GGG', '0N0 7845', 'Toyota', 'Yaris', 'Osobní automobil', 'Žlutá', 3, 1),
(5, 'W9E8RE4DF4DF6S4F6D', '3AQ 0142', 'BMW', 'x5', 'Terénní automobil', 'Modrá', 4, 1),
(6, 'PO1PU4I81Z2H1G3H6F', '5V0 5555', 'Škoda', 'Superb', 'Osobní automobil', 'Èervená', 5, 1),
(7, 'C9EWRQQ113C4GSDDDF', '4A4 0124', 'Škoda', 'Octavia', 'Osobní automobil', 'Žlutá', 6, 1),
(8, 'R9G11V41FG4GG4F8G4', '9V9 6789', 'Iveco', 'Crossway', 'Autobus', 'Modrá', 6, 1),
(9, 'WER7EWREWR4WER4G1G', '3B5 6124', 'Škoda', 'Yati', 'Terénní automobil', 'Žlutá', 6, 1),
(10, '1NN1B1V65BVB10VBV', '1B4 4575', 'Suzuki', 'V-Strom', 'Motorka', 'Èerná', 7, 1),
(12, 'WE9R8T4D1WQ1D1F4F', '3N1 1234', 'Harley Davidson', 'Street Rod 750', 'Motorka', 'Èervená', 8, 1),
(13, 'DF5W9E4T8DG4DSFD4S', '6F5 4573', 'Škoda', 'Kodiaq', 'Terénní automobil', 'Èervená', 9, 1),
(14, 'FDF1FC2B15D4FSDF4S', '8Q7 1345', 'Harley Davidson', 'Street Rod 500', 'Motorka', 'Modrá', 10, 1),
(15, 'QWERTZRRTR48451DFF', '3F9 3214', 'Zetor', '', 'Zemìdìlské a lesnické stroje', 'Modrá', 15, 1),
(16, 'POIUZTRF51GDF1555D', '9E8 3697', 'Škoda', 'Karoq', 'Terénní automobil', 'Èerná', 11, 1),
(17, 'MN1BVCD5G15G151FG5', '9QW 6754', 'Škoda', 'Octavia', 'Osobní automobil', 'Èervená', 13, 1),
(18, 'PLMTREWDFB474G48F8', '6S6 6666', 'Ford', 'Mustang', 'Osobní automobil', 'Èerná', 19, 1)
SET IDENTITY_INSERT [Vehicle] OFF



INSERT into [DriversGroups] (driverID, groupID)
VALUES 
(1, 4),
(1, 2),
(2, 3),
(2, 4),
(2, 6),
(3, 4),
(4, 4),
(5, 4),
(6, 4),
(6, 5),
(6, 7),
(7, 9),
(9, 8),
(8, 2),
(8, 4),
(10, 4),
(11, 4),
(12, 4),
(13, 4),
(14, 4),
(15, 4),
(16, 4),
(17, 4),
(18, 4),
(19, 4),
(20, 4),
(19, 6),
(18, 8),
(17, 10),
(16, 13),
(14, 13),
(10, 8),
(18, 1),
(15, 2),
(13, 2),
(13, 1),
(13, 5),
(13, 6),
(13, 7),
(13, 8),
(13, 9),
(14, 8),
(16, 11),
(8, 12),
(6, 13)


SET IDENTITY_INSERT [Employee] ON 
INSERT into [Employee] (ID, Name, Rank, officeID, State, Password)
VALUES 
(1, 'František Svoboda', 'Dustojnik', 8, 1, 'pass'),
(2, 'Petr Máèel', 'Praporcik', 7, 1, 'pass'),
(3, 'Dalibor Zeman', 'Praporcik', 6, 1, 'pass'),
(4, 'Marek Vašut', 'Praporcik', 5, 1, 'pass'),
(5, 'Karel Sedláèek', 'Praporcik', 4, 1, 'pass'),
(6, 'Jan Pokorný', 'General', 3, 1, 'pass'),
(7, 'Dominik Kuèera', 'Praporcik', 2, 1, 'pass'),
(8, 'Lukáš Procházka', 'Praporcik', 1, 1, 'pass'),
(9, 'Jan Král', 'Dustojnik', 2, 1, 'pass'),
(10, 'David Hájek', 'Dustojnik', 3, 1, 'pass'),
(11, 'Tomáš Doležal', 'Praporcik', 4, 1, 'pass'),
(12, 'Petr Sedláèek', 'Dustojnik', 5, 1, 'pass'),
(13, 'Marek Jelínek', 'Praporcik', 6, 1, 'pass'),
(14, 'Vlastimil Èerný', 'Praporcik', 7, 1, 'pass'),
(15, 'Václav Novotný', 'Praporcik', 8, 1, 'pass'),
(16, 'David Novák', 'Dustojnik', 1, 1, 'pass'),
(17, 'Václav Horák', 'Praporcik', 3, 1, 'pass'),
(18, 'Lukáš Pospíšil', 'Praporcik', 3, 1, 'pass'),
(19, 'Jan Koláø', 'Dustojnik', 3, 1, 'pass'),
(20, 'Dominik Kopecký', 'General', 4, 1, 'pass'),
(21, 'Jan Musil', 'Dustojnik', 4, 1, 'pass'),
(22, 'Vlastimil Polák', 'Dustojnik', 4, 1, 'pass')
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Record] ON 
INSERT into [Record] (ID, Ammount, PointsTaken, DateOfEntry, ExpireDate, PaidDate, driverID, employeeID, fineTypeID)
VALUES 
(1, 1000, 1, '10.10.2015', '10.11.2015', '15.10.2015', 1, 22, 8),
(2, 5000, 5, '5.10.2016', '5.11.2016', '10.10.2016', 2, 21, 7),
(3, 2000, 2, '1.5.2017', '1.6.2017', NULL, 3, 20, 6),
(4, 300, 0, '1.1.2016', '1.2.2016', '20.1.2016', 4, 20, 5),
(5, 100, 0, '3.8.2015', '3.9.2015', '10.8.2015', 5, 5, 4),
(6, 10000, 3, '20.10.2017', '20.11.2017', '30.10.2017', 5, 4, 3),
(7, 5000, 2, '6.2.2016', '6.3.2016', '20.2.2016', 5, 3, 1),
(8, 800, 0, '2.7.2015', '2.8.2015', NULL, 6, 2, 1),
(9, 7000, 3, '10.3.2015', '10.4.2015', '20.3.2015', 7, 1, 1),
(10, 400, 0, '2.2.2017', '2.3.2017', '20.2.2017', 3, 10, 6),
(11, 1000, 1, '7.7.2017', '7.8.2017', NULL, 10, 14, 6),
(12, 2000, 1, '6.5.2015', '6.6.2015', '26.5.2015', 8, 15, 6),
(13, 3000, 2, '20.12.2015', '20.1.2015', NULL, 15, 16, 6),
(14, 4000, 3, '1.12.2017', '1.1.2017', '20.12.2017', 16, 17, 6),
(15, 7000, 3, '10.10.2015', '10.11.2015', '20.10.2015', 17, 5, 3),
(16, 20000, 5, '8.5.2015', '8.6.2015', NULL, 18, 6, 7),
(17, 50000, 7, '20.2.2017', '20.3.2017', NULL, 19, 7, 6),
(18, 40000, 6, '6.6.2017', '6.7.2017', NULL, 20, 3, 7),
(19, 200, 0, '15.10.2017', '15.11.2017', '25.10.2017', 14, 2, 3),
(20, 5000, 2, '7.7.2016', '7.8.2016', '25.7.2016', 10, 1, 4),
(21, 6000, 2, '7.5.2016', '7.6.2016', '10.5.2016', 10, 1, 4),
(22, 300, 0, '1.5.2016', '1.6.2016', '10.5.2016', 8, 2, 3),
(23, 500, 0, '14.5.2016', '14.6.2016', '20.5.2016', 4, 2, 3),
(24, 100, 0, '4.5.2016', '4.6.2016', '10.5.2016', 21, 1, 1)
SET IDENTITY_INSERT [Record] OFF




INSERT into [Record] (Ammount, PointsTaken, DateOfEntry, ExpireDate, PaidDate, driverID, employeeID, fineTypeID)
VALUES 
(500, 0, '14.5.2016', '14.6.2016', '20.5.2016', 4, 2, 3),
(500, 0, '14.5.2016', '14.6.2016', '20.5.2016', 4, 2, 3),
(500, 0, '14.5.2016', '14.6.2016', '20.5.2016', 4, 2, 3),
(500, 0, '14.5.2016', '14.6.2016', '20.5.2016', 4, 2, 3);

select * from record where driverid = 4