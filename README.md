# employee-aspnet-web-api

## Department

GET api/Department

POST api/Department	
```JSON
{
  "ID": 1,
  "DepartmentName": "sample string 2"
}
```
PUT api/Department	

DELETE api/Department/{id}	

## Employee

GET api/Employee	

POST api/Employee	
```JSON
{
  "EmployeeID": 1,
  "EmployeeName": "sample string 2",
  "Department": "sample string 3",
  "MailID": "sample string 4",
  "DOJ": "2021-06-25T00:24:14.2740724+03:00"
}

```
PUT api/Employee	

DELETE api/Employee/{id}
