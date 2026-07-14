<h1 align="center">🎮 GameTest Backend API</h1>

<hr>

<h2>📖 О ПРОЕКТЕ</h2>
<p>Бэкенд для игры в жанре Survivor-like. Построен на <strong>Clean Architecture</strong>, <strong>DDD</strong> и <strong>CQRS + MediatR</strong>.</p>

<p><strong>Стек:</strong> ASP.NET Core 9, Entity Framework Core 9, MySQL 8, JWT, FluentValidation</p>

<hr>

<h2>📁 СТРУКТУРА ПРОЕКТА</h2>

<ul>
  <li><strong>GameTest.Domain</strong> — Сущности, Value Objects, Enums, Exceptions</li>
  <li><strong>GameTest.Domain.Tests</strong> — Модульные тесты для доменных сущностей (xUnit)</li>
  <li><strong>GameTest.Application</strong> — CQRS, MediatR, Handlers, DTOs, Interfaces</li>
  <li><strong>GameTest.Infrastructure</strong> — DbContext, Configurations, Migrations</li>
  <li><strong>GameTest.API</strong> — Controllers, Middleware, Swagger</li>
</ul>

<hr>

<h2>📡 API ENDPOINTS</h2>

<h3>🔓 Auth (Публичные)</h3>

<h4>POST /api/auth/register</h4>
<pre>
{
  "nickname": "Vasya",
  "email": "vasya@mail.com",
  "password": "password123"
}
</pre>

<h4>POST /api/auth/login</h4>
<pre>
{
  "email": "vasya@mail.com",
  "password": "password123"
}
</pre>

<strong>Response:</strong>
<pre>
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
</pre>

<hr>

<h3>🔒 PlayerProfile (Требуется JWT)</h3>

<h4>GET /api/player-profile</h4>
<strong>Response:</strong>
<pre>
{
  "nickname": "Vasya",
  "email": "vasya@mail.com",
  "registeredAt": "2026-07-14T12:00:00Z",
  "gold": 1000,
  "totalKills": 0
}
</pre>

<h4>PATCH /api/player-profile/nickname</h4>
<pre>
{
  "newNickname": "VasyaPro"
}
</pre>
<strong>Response:</strong> <code>204 No Content</code>

<hr>

<h3>📦 Catalog (Требуется JWT)</h3>

<ul>
  <li><code>GET /api/catalog/weapons</code></li>
  <li><code>GET /api/catalog/items</code></li>
  <li><code>GET /api/catalog/units</code></li>
  <li><code>GET /api/catalog/enemies</code></li>
  <li><code>GET /api/catalog/weapon-stats</code></li>
  <li><code>GET /api/catalog/unit-stats</code></li>
  <li><code>GET /api/catalog/enemy-stats</code></li>
</ul>

<hr>

<h3>🎮 PlayerProgression (Требуется JWT)</h3>

<h4>GET /api/player-progression/player-items?Page=1&Size=20&Type=Gloves</h4>

<h4>GET /api/player-progression/player-items/{id}</h4>

<h4>PATCH /api/player-progression/player-items/{id}/upgrade</h4>
<strong>Response:</strong>
<pre>
{
  "playerItemId": 1,
  "newLevel": 2,
  "newEffectBonus": 10.0,
  "newPlayerGold": 900,
  "nextLevelPrice": 200,
  "nextLevelEffectBonus": 15.0
}
</pre>

<h4>GET /api/player-progression/player-units</h4>
<h4>GET /api/player-progression/player-units/{id}</h4>
<h4>GET /api/player-progression/player-weapons</h4>
<h4>GET /api/player-progression/player-weapons/{id}</h4>

<h4>PATCH /api/player-progression/player-unit-properties/{id}/upgrade</h4>
<strong>Response:</strong>
<pre>
{
  "playerUnitPropertyId": 1,
  "newLevel": 2,
  "newValue": 15.0,
  "newPlayerGold": 900,
  "nextLevelPrice": 200,
  "nextLevelValue": 20.0
}
</pre>

<h4>PATCH /api/player-progression/player-weapon-properties/{id}/upgrade</h4>
<strong>Response:</strong>
<pre>
{
  "playerWeaponPropertyId": 1,
  "newLevel": 2,
  "newValue": 15.0,
  "newPlayerGold": 900,
  "nextLevelPrice": 200,
  "nextLevelValue": 20.0
}
</pre>

<hr>

<h3>🏃 Runs (Требуется JWT)</h3>

<h4>POST /api/runs</h4>
<strong>Request:</strong>
<pre>
{
  "idempotencyKey": "550e8400-e29b-41d4-a716-446655440000",
  "unitId": 1,
  "startedAt": "2026-07-14T12:00:00Z",
  "durationSeconds": 300,
  "kills": 150,
  "goldEarned": 500,
  "levelReached": 10
}
</pre>
<strong>Response (201 Created):</strong>
<pre>
{
  "runId": 1,
  "unitId": 1,
  "unitName": "Warrior",
  "startedAt": "2026-07-14T12:00:00Z",
  "durationSeconds": 300,
  "kills": 150,
  "goldEarned": 500,
  "levelReached": 10
}
</pre>

<h4>GET /api/runs?Page=1&Size=20&NewestFirst=true</h4>
<h4>GET /api/runs/{id}</h4>
<h4>GET /api/runs/best</h4>

<hr>

<h2>🧪 ТЕСТИРОВАНИЕ</h2>

<p>Проект покрыт модульными тестами для доменных сущностей (GameTest.Domain.Tests).</p>

<strong>Запуск тестов:</strong>
<pre>
dotnet test GameTest.Domain.Tests
</pre>

<hr>

<h2>🛠️ УСТАНОВКА И ЗАПУСК</h2>

<h3>1. Клонировать репозиторий</h3>
<pre>
git clone https://github.com/yourusername/gametest-backend.git
cd gametest-backend
</pre>

<h3>2. Настроить базу данных (Docker)</h3>
<pre>
docker-compose up -d
</pre>
<p>Или вручную:</p>
<pre>
docker run -d --name gametest-mysql -e MYSQL_DATABASE=gametest -e MYSQL_USER=gametest -e MYSQL_PASSWORD=gametest_password -e MYSQL_ROOT_PASSWORD=root_password -p 3307:3306 mysql:8.0
</pre>

<h3>3. Настроить appsettings.json</h3>
<pre>
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3307;Database=gametest;User=root;Password=root_password;"
  },
  "Jwt": {
    "Key": "your-super-secret-key-at-least-32-characters-long",
    "Issuer": "gametest-api"
  }
}
</pre>

<h3>4. Применить миграции</h3>
<pre>
dotnet ef database update --project GameTest.Infrastructure --startup-project GameTest.API
</pre>

<h3>5. Запустить API</h3>
<pre>
cd GameTest.API
dotnet run
</pre>

<hr>

<h2>📦 УСТАНОВКА ПАКЕТОВ</h2>

<h3>GameTest.API</h3>
<pre>
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 9.0.0
dotnet add package Swashbuckle.AspNetCore --version 7.2.0
</pre>

<h3>GameTest.Application</h3>
<pre>
dotnet add package MediatR --version 12.4.1
dotnet add package FluentValidation --version 11.11.0
</pre>

<h3>GameTest.Infrastructure</h3>
<pre>
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0-preview.1
</pre>

<h3>GameTest.Domain.Tests</h3>
<pre>
dotnet add package xunit --version 2.6.6
dotnet add package xunit.runner.visualstudio --version 2.5.6
dotnet add package Moq --version 4.20.70
dotnet add package FluentAssertions --version 6.12.0
</pre>

<hr>

<h2>💡 КЛЮЧЕВЫЕ ФИЧИ</h2>

<ul>
  <li><strong>CQRS + MediatR</strong> — строгое разделение команд и запросов</li>
  <li><strong>Clean Architecture</strong> — независимость от внешних слоёв</li>
  <li><strong>Гибкая система прокачки</strong> — один механизм для оружия, предметов и юнитов</li>
  <li><strong>Idempotency</strong> — защита от дублирования забегов</li>
  <li><strong>Глобальная обработка ошибок</strong> — единый middleware</li>
  <li><strong>JWT Authentication</strong> — авторизация через токены</li>
  <li><strong>Domain Tests</strong> — модульные тесты (xUnit, Moq, FluentAssertions)</li>
</ul>

<hr>

<p align="center"><strong>Разработчик:</strong> Денисенко Никита</p>
<p align="center">Проект готов к интеграции с клиентской частью (Unity).</p>
