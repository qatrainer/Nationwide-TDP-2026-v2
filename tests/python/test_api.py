# NW TDP 2026 v2
from fastapi.testclient import TestClient
from app.main import app

client = TestClient(app)

def test_health_endpoint_returns_healthy():
    response = client.get("/health")
    assert response.status_code == 200
    assert response.json()["status"] == "healthy"

def test_calculate_accepts_valid_spending():
    response = client.post("/calculate", json={"spending": [{"category": "Travel", "amount": 25}]})
    assert response.status_code == 200
    assert response.json()["totalCarbonKg"] == 0
    assert response.json()["breakdown"][0]["category"] == "Travel"

def test_calculate_rejects_negative_spending():
    response = client.post("/calculate", json={"spending": [{"category": "Travel", "amount": -1}]})
    assert response.status_code == 422

def test_calculate_requires_spending_items():
    response = client.post("/calculate", json={"spending": []})
    assert response.status_code == 422
