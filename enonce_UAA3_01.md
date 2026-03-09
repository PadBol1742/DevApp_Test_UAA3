# Test Développeur - UAA3 (Tache 1)
Analyse d'une demande client et intervention sur une Application existante (DeskReserve)  

## Contexte de l'épreuve

Vous êtes développeur/développeuse Junior au sein d'une Entreprise de Services du Numérique (ESN). Vous venez d'être affecté(e) à la maintenance d'un projet existant nommé **DeskReserve**, une application web de réservation d'espaces de coworking. 

L'application est fonctionnelle et en production. Elle est composée :
* D'une API Backend en **ASP.NET Core** (C#) connectée à une base de données **MSSQL**.
* D'une interface Frontend en **React**.

Ce matin, votre chef de projet (votre N+1) vous transfère un e-mail direct du client contenant plusieurs retours et nouvelles demandes. 

---

## Cahier des Charges (Demande Client)

Voici le message transféré par le client que vous devez traiter aujourd'hui :

> **De :** Jean-Marc (Client - DeskReserve)
> **À :** Équipe de développement
> **Objet :** Retours urgents sur l'application et nouvelles demandes
> 
> Bonjour l'équipe,
> 
> L'application tourne bien globalement, mais nous avons eu quelques retours de nos utilisateurs cette semaine. Il faudrait traiter ces points le plus rapidement possible :
> 
> **1. Problème de réservation :** Plusieurs employés ont réussi à réserver le bureau "OpenSpace-A4" mardi dernier pour la même journée. Ça a créé des conflits sur place. Il ne devrait pas être possible de réserver un bureau s'il est déjà pris à cette date.
> 
> **2. Bug lors de l'annulation :** Quand un utilisateur clique sur "Annuler ma réservation", la réservation est bien supprimée (je le vois dans la base de données), mais l'application web fige complètement et affiche un écran blanc. Il faut rafraîchir la page pour que ça revienne à la normale.
> 
> **3. Confirmation par e-mail :** Actuellement, les gens ne sont pas sûrs que leur réservation a fonctionné. Je voudrais que l'application envoie automatiquement un e-mail de confirmation à l'utilisateur dès qu'il valide sa réservation. Merci de mettre ça en place.
> 
> **4. Application Mobile :** Notre direction est très contente du projet et souhaite passer à la vitesse supérieure. Puisque vous avez fait l'application web en React, nous voulons que l'application soit disponible au téléchargement sur l'Apple App Store et le Google Play Store d'ici la semaine prochaine. Merci de faire le changement de plateforme.
> 
> J'attends votre retour rapide sur ces points.
> 
> Cordialement,  
> Jean-Marc

---

## Votre Mission

En tant que développeur sur ce projet, vous devez prendre en charge cette demande.  
Votre travail se divise en trois axes :

### 1. Analyse de la demande
Prenez connaissance de l'application (code source fourni) et analysez les requêtes de Jean-Marc. Vous devez évaluer les impacts techniques de chaque point demandé sur l'architecture existante.

### 2. Périmètre d'intervention (Code)
Identifiez parmi les 4 demandes du client celles qui relèvent **strictement de votre périmètre d'action** immédiat en tant que développeur web junior affecté à la maintenance.
* **Corrigez dans le code source** les éléments défaillants qui sont dans votre scope. 
* *Indice : Il est attendu que vous ne réalisiez pas l'intégralité des demandes du client aujourd'hui.*

### 3. Communication avec votre N+1 (Livrable écrit)
Rédigez un message (simulant un e-mail ou un message sur l'outil de communication de votre entreprise) destiné à votre supérieur hiérarchique (N+1). Ce message doit impérativement :
* **Justifier les impacts** de l'intégration de vos modifications (ce que la correction a impliqué techniquement).
* **Signaler et justifier techniquement** pourquoi vous ne pouvez/devez pas réaliser la (ou les) demande(s) qui sortent de votre périmètre.
* **Mettre en évidence un élément bloquant/manquant** pour mener à bien l'une des demandes métier, en formulant une demande d'informations complémentaires claire. N'hésitez pas à être force de proposition technique (librairie, standard, etc.).
* **Proposer un ordre du jour** clair (sous forme de liste) pour une courte réunion d'équipe afin de faire le point sur ce ticket client.

---

## Critères d'Évaluation

Votre travail sera évalué sur les points suivants :

**Hard Skills (Technique & Code)**
* La capacité à lire et comprendre une architecture existante.
* Les parties de l’application existante modifiées ou corrigées sont pleinement fonctionnelles.
* Le code produit est propre, n'introduit pas de nouveaux bugs et respecte les conventions du projet.

**Soft Skills (Analyse & Posture Professionnelle)**
* Le périmètre d’intervention est correctement identifié (vous avez su dire "non" aux bonnes tâches).
* La justification des tâches hors-périmètre démontre une bonne compréhension des enjeux techniques (plateformes, architectures, délais).
* L'analyse des impacts de vos modifications est pertinente.

**Soft Skills (Communication)**
* Le message adressé au N+1 est professionnel, clair et structuré.
* L'identification du besoin d'informations complémentaires (les éléments manquants) est pertinente et proactive.
* L'ordre du jour proposé pour la réunion est concis et pertinent.