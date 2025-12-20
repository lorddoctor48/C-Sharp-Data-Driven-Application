--Custom Stored Procedure
CREATE   PROCEDURE DeleteEntertainmentActivitiesByDateStartTime
	@DateStartTime DATETIME
AS
BEGIN
    SET NOCOUNT ON;    

	DELETE EA
    FROM EntertainmentActivities AS EA
    JOIN Activities AS A ON A.ActivityID = EA.ActivityID
    WHERE A.DateStartTime = @DateStartTime;

    DELETE A
    FROM Activities AS A
    JOIN EntertainmentActivities AS EA ON A.ActivityID = EA.ActivityID
	WHERE DateStartTime = @DateStartTime;
END