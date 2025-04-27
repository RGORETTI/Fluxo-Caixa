@echo off
echo ========================================
echo Parando o container atual...
echo ========================================
docker-compose down

echo ========================================
echo Removendo a imagem antiga...
echo ========================================
docker rmi fluxo-caixa-fluxo-caixa-api

echo ========================================
echo Rebuildando e subindo o container...
echo ========================================
docker-compose up --build -d

echo ========================================
echo Container rebuildado e iniciado com sucesso!
pause
