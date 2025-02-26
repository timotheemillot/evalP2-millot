import { Component } from '@angular/core';
import {RouterLink} from '@angular/router';
import {Application} from '../../../models/application';
import {ApplicationsService} from '../../../services/applications/applications.service';
import {NgForOf} from '@angular/common';

@Component({
  selector: 'app-applications-list',
  imports: [
    RouterLink,
    NgForOf
  ],
  templateUrl: './applications-list.component.html',
  standalone: true,
  styleUrl: './applications-list.component.css'
})

//Affichage des applications disponibles
export class ApplicationsListComponent {

  constructor(private applicationService: ApplicationsService) {
    this.loadApps();
  }

  applications : Application[] = [];

  loadApps() {
    try{
      this.applicationService.getApplications().subscribe((data : Application[])=>{
        this.applications = data;
      });
    }
    catch (e) {
      console.log(e);
    }


  }
}
