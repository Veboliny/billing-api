# Variables pour les services
COMPOSE_FILE=docker-compose.yml
DB_CONTAINER_NAME=postgres_container

# Commande pour lancer les services (PostgreSQL) via docker-compose
up:
	@docker-compose -f $(COMPOSE_FILE) up --build -d

# Commande pour arr�ter les services
down:
	@docker-compose -f $(COMPOSE_FILE) down

# Commande pour afficher les logs des deux conteneurs
logs:
	@docker-compose -f $(COMPOSE_FILE) logs -f

# Commande pour se connecter � PostgreSQL depuis le conteneur de base de donn�es
psql:
	@docker exec -it $(DB_CONTAINER_NAME) psql -U postgres

# Makefile pour nettoyer tous les conteneurs, images, volumes et le r�pertoire de donn�es
# Assure-toi que Docker est en cours d'ex�cution avant d'ex�cuter ces commandes.

# Cible de nettoyage complet avec les datas
clean:
	docker-compose down --remove-orphans -v


# Commande pour reconstruire les conteneurs si n�cessaire
rebuild:
	@docker-compose -f $(COMPOSE_FILE) up --build -d --force-recreate

# TODO : 
# FIXTURE DB
# MAKE DB FIXTURE : 
# Architecture :
# Avec les commandes : dotnet ef migrations CreateUserTable -> dotnet ef database update
# Ajout de donn�es : 
# 