import { Routes } from '@angular/router';
import {ApplicationsComponent} from './components/applications/applications.component';
import {CreateApplicationComponent} from './components/applications/create/create-application.component';
import {PasswordsComponent} from './components/passwords/passwords.component';
import {CreatePasswordComponent} from './components/passwords/create/create-password.component';
import {ViewPasswordComponent} from './components/passwords/view/view-password.component';

export const routes: Routes = [

  // Il est possible d'accéder aux pages via du routing Angular.
  //Utiliser des routes avec des paramètres dynamiques pour accéder aux mots de passe enregistrés.
  //Assurer une navigation fluide avec un RouterLink dans les composants Angular.

  { path: 'applications', component: ApplicationsComponent },
  { path: 'applications/create', component: CreateApplicationComponent },
  { path: 'passwords', component: PasswordsComponent },
  { path: 'passwords/create', component: CreatePasswordComponent },
  { path: 'passwords/:id', component: ViewPasswordComponent },

  // Gérer une redirection vers la page principale en cas de tentative d'accès à une page inexistante.
  { path: '**', redirectTo: 'applications', pathMatch: 'full' }
];

