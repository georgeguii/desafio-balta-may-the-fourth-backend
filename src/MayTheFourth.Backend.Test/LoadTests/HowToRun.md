
# Como Executar Testes do k6

Para executar testes do k6, siga estas etapas simples:

## 1. Instala��o do k6

Certifique-se de ter o k6 instalado em seu sistema. Se ainda n�o o fez, voc� pode seguir as instru��es de instala��o no [site oficial do k6](https://grafana.com/docs/k6/latest/set-up/install-k6/).

## 2. Configura��o do Painel Web (Opcional)

Se desejar visualizar os resultados dos testes em um painel web, voc� pode ativar o painel web do k6. Isso pode ser feito definindo a vari�vel de ambiente `k6_WEB_DASHBOARD` como `true`.

```bash
k6_WEB_DASHBOARD=true
```
## 3. Execu��o dos Testes 

Para executar seus testes, utilize o seguinte comando, substituindo `{script.js}` pelo caminho para o seu script de teste:

 ```bash
k6 run --env MY_HOSTNAME={httpsHostName} --env K6_WEB_DASHBOARD=true {script.js}
```

Por exemplo:
 ```bash
k6 run --env MY_HOSTNAME=localhost:7027 --env K6_WEB_DASHBOARD=true GetAllFilms.js
```

## 4. Visualiza��o dos Resultados (Opcional)

Se voc� ativou o painel web do k6, pode visualizar os resultados dos testes navegando para http://localhost:5665/](http://localhost:5665/) em seu navegador ap�s iniciar os testes.
