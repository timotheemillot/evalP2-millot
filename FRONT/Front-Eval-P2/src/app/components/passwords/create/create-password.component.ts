import { Component } from '@angular/core';
import {PasswordsService} from '../../../services/passwords/passwords.service';
import {ApplicationsService} from '../../../services/applications/applications.service';
import {Application} from '../../../models/application';
import {NgForOf} from '@angular/common';
import {Password} from '../../../models/password';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-create-password',
  imports: [
    NgForOf,
    FormsModule
  ],
  templateUrl: './create-password.component.html',
  standalone: true,
  styleUrl: './create-password.component.css'
})
export class CreatePasswordComponent {

  constructor(private readonly passwordService: PasswordsService, private readonly applicationService: ApplicationsService) {
    this.loadApps();
  }

  applications : Application[] = [];
  selectedAppId : number = 0;
  username : string = '';
  password : string = '';

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

  onFormSubmit() {

    let passwordApp = new Application(this.selectedAppId, '', false);
    passwordApp.id = this.selectedAppId;

    let password = new Password(
      0,
      this.username,
      this.password,
      passwordApp
    );

    this.passwordService.createPassword(password).subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (error) => {
        console.log(error.error);
      }
    });
  }



}
