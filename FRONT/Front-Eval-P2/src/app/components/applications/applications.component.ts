import { Component } from '@angular/core';
import {ApplicationsListComponent} from './list/applications-list.component';

@Component({
  selector: 'app-applications',
  imports: [
    ApplicationsListComponent
  ],
  templateUrl: './applications.component.html',
  standalone: true,
  styleUrl: './applications.component.css'
})

// Affichage des applications disponibles et possibilité d’en ajouter
export class ApplicationsComponent {

}
