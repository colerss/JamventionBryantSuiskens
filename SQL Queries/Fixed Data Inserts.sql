
INSERT INTO JAM.Residences
(ResidenceID, PostalCode, City, Address, NationalityID)
VALUES
(1, '2323', 'Wortel', 'Sintjanstraat16E', 17),
(2, '2323', 'Wortel', 'Sintjanstraat16E', 17),
(3, '2323', 'Wortel', 'Sintjanstraat16E', 17),
(4, '2323', 'Wortel', 'Sintjanstraat16E', 17),
(5, '2323', 'Wortel', 'Sintjanstraat16E', 17);
INSERT INTO JAM.Guests
(GuestID, FirstName, LastName, ResidenceID, EmailAddress, TelephoneNR, IsVegetarian, RoleID, InvoiceID, RoomID)
VALUES
(1, 'Willy', 'Suiskens', 1, 'Test@Test', '03Test', 0, ),
;