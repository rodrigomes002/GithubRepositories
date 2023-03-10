
## Documentação da API

#### Retorna todos os repositórios por filtro

```http
  POST /api/v1/repositores/listByFilter
```

| Body   | Tipo       |
| :---------- | :--------- |
| `{ "page": 1, "pageSize": 10, "allContent": false, "idsRep": [], "languages": [ "JavaScript", "Java", "csharp", "c", "python" ] }` | `json` |

#### Retorna todos os repositórios

```http
  GET /api/v1/repositores/listAll
```

