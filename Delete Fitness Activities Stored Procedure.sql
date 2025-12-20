--Custom Stored Procedure
CREATE OR ALTER  PROCEDURE DeleteFitnessActivitiesByDateStartTime
	@DateStartTime DATETIME
AS
BEGIN
    SET NOCOUNT ON;    

    DELETE FA
    FROM FitnessActivities AS FA
    JOIN Activities AS A ON A.ActivityID = FA.ActivityID
    WHERE A.DateStartTime = @DateStartTime;

    DELETE A
    FROM Activities AS A
	WHERE DateStartTime = @DateStartTime;
END