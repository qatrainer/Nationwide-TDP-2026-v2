<<<<<<< HEAD
<!-- NW TDP 2026 v2 -->
# Nationwide TDP 2026 Capstone — Starter Repository (V2)

This starter provides two interchangeable backend starting points: **C#/.NET 8** and **Python 3.14**. Teams should select one backend for their MVP. Both are included so teams can choose; the sample CI workflow initially validates both.

## Repository layout

- `api/csharp/` — minimal ASP.NET Core API
- `api/python/` — FastAPI implementation
- `tests/csharp/` — xUnit API tests
- `tests/python/` — pytest API tests
- `database/` — T-SQL schema and seed data
- `frontend/` — simple starter customer interface
- `test-data/` — synthetic sample spending datasets
- `.github/workflows/devsecops.yml` — build, test, SAST, SCA, DAST and deployment gate
- `docs/devsecops.md` — pipeline guidance

## API endpoints

Both implementations provide:

- `GET /health`
- `POST /calculate`

Example request:

```json
{
  "spending": [
    { "category": "Travel", "amount": 25 },
    { "category": "Food", "amount": 40 }
  ]
}
```

The calculation endpoint is deliberately a placeholder and returns zero carbon until the team implements emissions-factor lookups and calculation logic in Sprint 2.

## Choose your backend

### Python 3.14

```bash
cd api/python
python -m venv .venv
# Windows: .venv\Scripts\activate
# Linux/macOS: source .venv/bin/activate
pip install -r requirements-dev.txt
uvicorn app.main:app --reload
```

Run tests from `api/python`:

```bash
PYTHONPATH=. pytest ../../tests/python -q
```

### C# / .NET 8

Run the API:

```bash
dotnet run --project api/csharp/Nationwide.Api/Nationwide.Api.csproj
```

Run tests:

```bash
dotnet test tests/csharp/Nationwide.Api.Tests/Nationwide.Api.Tests.csproj
```

## DevSecOps

The GitHub Actions pipeline demonstrates:

1. Build and automated tests
2. SAST using GitHub CodeQL
3. SCA using `pip-audit` and .NET vulnerable-package reporting
4. DAST using OWASP ZAP against the running Python API
5. A deployment gate placeholder

See [`docs/devsecops.md`](docs/devsecops.md). Add deployment only after configuring protected GitHub environments, cloud identity and secrets. Never commit credentials.

## Sprint 1 focus

Establish the repository, select a backend, prove the API and tests run, create the SQL schema/seed data, and demonstrate the security pipeline. Real carbon calculations, SQL integration and recommendations are Sprint 2 work.

All supplied customer data is synthetic. Do not add real customer information.
=======
# Nationwide-TDP-2026-v2
Nationwide-TDP-2026-v2 Captstone Project
>>>>>>> f6e492648e7f2df060fb5e2a1def2a6271d62ea6
