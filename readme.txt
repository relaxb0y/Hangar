#  Ангар літаків.
##  Функціональні вимоги:
###  Аеродором:
####  Типовий представник пілот:
-  Повинен мати можливість вести моніторинг усіх наявних в ангарах літаків (GET) та моніторинг конкретного літака (GET by ID);
###  Ангар:
####  Типовий представник пілот:
-  Повинен мати можливість вести моніторинг усіх наявних в ангарі літаків (GET) та моніторинг конкретного літака (GET by ID);
-  Повинен мати можливість додавати літак у базу даних ангару (POST);
-  Повинен мати можливість вносити корективи у існуючі записи літаків (PUT та PATCH);
-  Повинен мати можливість видаляти конкретні записи ангару (DELETE);
##  Методи
###  Опис аеродрому:
####  GET:
Url: /api/v1/hangars
Вхідна модель: {}
Вихідна модель:
{
id : int, min=1, max=65535
address: string, min=1, max=255
}
Метод передбачає реалізацію pagination у розмірі п'яти елементів за один запит
У разі виникнення помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  GET(id):
Url: /api/v1/hangars/{id}
Вхідна модель: {id : int, min=1, max=65535}
Вихідна модель:
{
id : int, min=1, max=65535
address: string, min=1, max=255
}}
У разі виникнення помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  POST:
Url: /api/v1/hangars
Вхідна модель: 
{
id : int, min=1, max=65535
address: string, min=1, max=255
}
Вихідна модель:
{
id: int, min=1, max=65535
status: string, min=1, max=255
}
У разі виникнення помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  PUT(id):
Url: /api/v1/hangars/{id}
Вхідна модель: 
{
id : int, min=1, max=65535
address: string, min=1, max=255
}
Вихідна модель:
{
id: int min=1, max=65535
status: string, min=1, max=255
}
У разі виникнення помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
#### DELETE(id) 
Url: /api/v1/hangar/{id}
Вхідна модель: 
{ id: int, min=1, max=65535}
Вихідна модель:
{ isDeleted: string, min=1, max=255}
У разі виникнення помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)

###  Опис літаків:
####  GET:
Url: /api/v1/hangars/{hangarsId}/planes
Вхідна модель: {}
Вихідна модель:
{
id : int, min=1, max=65535
name: string, min=1, max=255
storage_data: string, min=1, max=255
description: string, min=1, max=255
}
Метод передбачає реалізацію pagination у розмірі п'яти елементів за один запит
У разі виникнення помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  GET(id):
Url: /api/v1/hangars/{hangarsId}/planes/{id}
Вхідна модель: {id : int, min=1, max=65535}
Вихідна модель:
{
id : int, min=1, max=65535
name: string, min=1, max=255
storage_data: string, min=1, max=255
description: string, min=1, max=255
}
У разі виникнення помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  POST:
Url: /api/v1/hangars/{hangarsId}/planes
Вхідна модель: 
{
id : int, min=1, max=65535
name: string, min=1, max=255
storage_data: string, min=1, max=255
description: string, min=1, max=255
}
Вихідна модель:
{
id: int, min=1, max=65535
status: string, min=1, max=255
}
У разі виникнення помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  PUT(id):
Url: /api/v1/hangars/{hangarsId}/planes/{id}
Вхідна модель: 
{
id : int, min=1, max=65535
name: string, min=1, max=255
storage_data: string, min=1, max=255
description: string, min=1, max=255
}
Вихідна модель:
{
id: int, min=1, max=65535
status: string, min=1, max=255
}
У разі виникнення помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
#### DELETE(id) 
Url: /api/v1/hangars/{hangarsId}/planes/{id}
Вхідна модель: 
{ id: int, min=1, max=65535}
Вихідна модель:
{ isDeleted: string, min=1, max=255}
У разі виникнення помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)

##  Нефункціональні вимоги:
-	Безпека та конфіденційність;
-	Надійність;
-	Відновлювальність;
-	Продуктивність (час виконання запитів не більше двох секунд);
-	Збереження даних;
-	Керування помилками.
