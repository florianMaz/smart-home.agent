#

## :bulb: dialogflow smart-home agent

### :construction: Introduction

Le but de ce projet est de construire un agent avec dialogflow qui a le super pouvoir de contrôler votre maison
:house_with_garden: ... intéliigente :wink: </br>
Une maison virtuelle est mis en place pour chaque groupe via openhab, un framework open source de domotique (home automation). </br>

#### 1. :electric_plug: Openhab

Openhab expose les différents devices via une interface de contrôle web ou via l'application mobile</br>
[![openhab-iOS](https://img.shields.io/static/v1?label=OPENHAB&message=IOS&color=BLACK&style=for-the-badge&logo=apple "download openhab")](https://apps.apple.com/us/app/openhab/id492054521)
[![openhab-android](https://img.shields.io/static/v1?label=OPENHAB&message=Android&color=GREEN&style=for-the-badge&logo=google-play "download openhab")](https://play.google.com/store/apps/details?id=org.openhab.habdroid) 
[![openhab-web](https://img.shields.io/static/v1?label=OPENHAB&message=WEB&color=BLACK&style=for-the-badge&logo=google-chrome "download openhab")](http://62.35.68.9:8080/basicui/app?sitemap=demo)</br>
Pour de brancher l'application sur l'instance openhab :black_circle: Settings </br>
:arrow_right: Remote URL :point_right: <http://62.35.68.9:8080> </br>
:arrow_right: Ignore SSL Certificates :point_right: :white_check_mark:

<p align="center">
  <img src="/docs/basic-ui-demo.png">
</p>

#### 2. :large_orange_diamond: Openhab Proxy API
Pour vous faciliter le développemnt, un proxy à été dévelopé afin de gérer une configuration (maison) par groupe et exposer un seul point d'accés pour tout le monde

Le proxy vous permettera de :
+ Générer à la volet vos entité dialogflow
+ Récupérer la configuration de votre groupe (masion, zones, chambres, devices)
+ Récupérer ou mettre à jour l'état d'un device
+ Un passe-plat (gateway) vers l'api ITEM de openhab (pour les plus fous :smiling_imp:)  

[![import-agent](https://img.shields.io/static/v1?label=quickstart-agent&message=download&color=BLUE&style=for-the-badge&logo=google-assistant "download quickstart-agent")](https://github.com/badreddine-dlaila/smart-home.agent/raw/master/src/quickstart-agent.zip)