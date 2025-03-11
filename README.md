# SurveySystem

need to set local db connection string
set SurveySystem as statup project
open package manager console in vs-> run following command that will create db on local system accroding to db name in connection string in appsettings.json or appsettings.devlopment.json if both set

set server on vs to https 
press run buttion 
swagger will open showing apis and structure


NOTE :
*) DataTransfer objects are not user currently that is in to do,which is causing bugs while excecuting api as virtual properties are also part of api currently.
as DB entities will be changed to DTOs in BLL apis will start working.

*) main project structure and opration flow with migration has been added

*) migration should be added to DAL project , that is also in to list.



