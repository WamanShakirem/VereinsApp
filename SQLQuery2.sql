SELECT Rechnung.Id, Rechnung.Betrag, Rechnung.Bezahldatum, Rechnung.MitgliedId, Personendaten.Vorname, Personendaten.Nachname
FROM Rechnung, Personendaten
WHERE Rechnung.MitgliedId = Personendaten.Id
ORDER BY Rechnung.Bezahldatum