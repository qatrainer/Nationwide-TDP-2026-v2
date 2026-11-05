<!-- NW TDP 2026 v2 -->
# DevSecOps pipeline

The starter pipeline demonstrates **Build → Test → SAST → SCA → DAST → Deploy gate**.

- Build/test: Python 3.14 (FastAPI/pytest) and C# (.NET 8/xUnit) starter implementations are both validated.
- SAST: GitHub CodeQL scans Python and C#.
- SCA: `pip-audit` checks Python dependencies; `dotnet list package --vulnerable` checks .NET dependencies.
- DAST: OWASP ZAP baseline scans the running Python API in CI.
- Deploy gate: a placeholder job marks the point where deployment can be added after the checks. No cloud credentials are included.

The pipeline validates both starter implementations. Teams should select one backend for their project and may remove the unused implementation/job after confirming the chosen path works.

## Interpreting findings

Review scanner output rather than assuming every alert is exploitable. Record the component, version, severity, evidence, decision, remediation and retest result. Set repository branch protection to require the relevant workflow checks. The ZAP baseline is configured not to fail the build automatically; teams/instructors should agree severity thresholds and change `fail_action` when the API and scan rules are stable.

## Run locally

### Python 3.14

```bash
cd api/python
python -m venv .venv
# Windows: .venv\Scripts\activate
# Linux/macOS: source .venv/bin/activate
pip install -r requirements-dev.txt
uvicorn app.main:app --reload
```

In another terminal:

```bash
cd api/python
PYTHONPATH=. pytest ../../tests/python -q
```

### C# / .NET 8

```bash
dotnet test tests/csharp/Nationwide.Api.Tests/Nationwide.Api.Tests.csproj
```

## Important

Both APIs currently return placeholder carbon values of zero. They do not yet calculate emissions or access the SQL database. Implement real factor lookups and calculation logic in Sprint 2. Do not commit secrets or real customer data.
