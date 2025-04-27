@echo off
echo ======================================
echo Iniciando o container Fluxo_Caixa...
echo ======================================
docker-compose up -d

echo Aguardando inicialização do container...
timeout /t 5

echo Abrindo o navegador no Swagger...
start "" "http://localhost:5000/swagger"

echo ======================================
echo Container iniciado e navegador aberto!
pause
