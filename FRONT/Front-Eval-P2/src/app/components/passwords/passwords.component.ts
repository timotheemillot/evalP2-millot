import { Component } from '@angular/core';
import {PasswordsListComponent} from './list/passwords-list.component';

@Component({
  selector: 'app-passwords',
  imports: [
    PasswordsListComponent
  ],
  templateUrl: './passwords.component.html',
  standalone: true,
  styleUrl: './passwords.component.css'
})
export class PasswordsComponent {

}
