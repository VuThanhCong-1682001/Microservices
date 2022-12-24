## Docker run
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remove-orphans

## Docker build and run
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --build --remove-orphans

## Application Services Urls:
**Development Environment**

- Api Gateway: https://localhost:5010
- Identity Service: https://localhost:5001
- OctoQual API: https://localhost:5002
- OctoQual Client MVC: https://localhost:6001