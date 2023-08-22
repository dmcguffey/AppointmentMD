# AppointmentMD
This application is designed to display, edit, delete, and create appointments located in a MySql database using Dapper.
The user will need to add access to their own database using appsettings.json.
This application is designed for usage for clinic staff only. Not for patient use.
The user can open the appointments page and view all appointments for the physicians in the clinic. By clicking ID numbers, the User can view
more detailed information on patients, physicians, and appointments. This is also where the user will edit the appointments.
The user may also filter appointments by physicianID in order to view appointments for one physician.
Physician info is set to be permanently added to the application. Likewise patient info is also permanent. Only appointments can be deleted.
Physicians table contains the PhysicianID, Name, Specialty in abbreviated format, and location of their office.
Patients table contains the PatientID, Name, DateOfBirth, Age, Gender, Diagnosis, and PhysicianID
Appointmetns contain AppointmentID, AppointmentStart, AppointmentEnd, PatientID, and PhysicianID
