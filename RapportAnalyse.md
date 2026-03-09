# RE: Retours urgents sur l'application et nouvelles demandes

Bonjour Pierre,

À la lecture du code source voici ce que je peux proposer :

**1. Problème de réservation :** Ce problème ne devrait pas être compliqué à régler, 1 à 2 heures de travail je dirais.

**2. Bug lors de l'annulation :** Je vois où doit se situer le problème dans le code mais je n'ai aucune idée de ce qui cloche là comme ça. Le code implique des fonction que je n'ai encore jamais vu, il va me falloir explorer la doc et faire des tests plus exploratoires. Sans doute une demi journée de travail.

**3. Confirmation par e-mail :** Pas bien compliqué à mettre en place, juste un peu de chipot. Disons quand même 2 bonnes heures pour la mise en place en tant que telle. Par contre j'aurais besoin des infos suivantes :
* SmtpHost
* SmtpPort
* Adresse email d'envoi
* Login de cette adresse email
* Mot de Passe de cette adresse email
* Contenu de l'email

**4. Application Mobile :** Je suppose qu'on se penchera sur la mise en place de ce point à la prochaine réunion parce que ça dépasse clairement mon périmètre d'action.


**NB.** À propos du BE Je suis surpris de retrouver les IServices dans le Domaine au lieu du dossier 'Interfaces' de l'AppCore mais modifier ça maintenant peut-être source de bugs aux autres niveaux. Il serait sans doute judicieux de corriger ça mais ça n'empêche à priori pas le fonctionnement dans l'immédiat donc seulement si on à le temps.

Bonne journée,
Laurent.