import { Routes } from '@angular/router';
import {ApplicationsComponent} from './components/applications/applications.component';
import {CreateApplicationComponent} from './components/applications/create/create-application.component';
import {PasswordsComponent} from './components/passwords/passwords.component';
import {CreatePasswordComponent} from './components/passwords/create/create-password.component';
import {ViewPasswordComponent} from './components/passwords/view/view-password.component';

export const routes: Routes = [
  { path: 'applications', component: ApplicationsComponent },
  { path: 'applications/create', component: CreateApplicationComponent },
  { path: 'passwords', component: PasswordsComponent },
  { path: 'passwords/create', component: CreatePasswordComponent },
  { path: 'passwords/:id', component: ViewPasswordComponent },

];

