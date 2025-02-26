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
export class CreateApplicationComponent {

  name: string = '';
  type: boolean = false;



  constructor(private readonly applicationService: ApplicationsService) {
  }

  onFormSubmit() {

    let application = new Application(
      0,
      this.name,
      this.type
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
