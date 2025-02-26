import { Component } from '@angular/core';
import {ApplicationsService} from '../../../services/applications/applications.service';
import {Application} from '../../../models/application';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-create-application',
  imports: [
    FormsModule
  ],
  templateUrl: './create-application.component.html',
  standalone: true,
  styleUrl: './create-application.component.css'
})

// Création d’une application
export class CreateApplicationComponent {

  name: string = '';
  type: number = 0;
  typeBoolean: boolean = false;



  constructor(private readonly applicationService: ApplicationsService) {
  }

  onFormSubmit() {

    this.type == 0 ? this.typeBoolean = false : this.typeBoolean = true;

    let application = new Application(
      0,
      this.name,
      this.typeBoolean
    );

    this.applicationService.createApplication(application).subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (error) => {
        console.log(error.error);
      }
    });
  }
}
