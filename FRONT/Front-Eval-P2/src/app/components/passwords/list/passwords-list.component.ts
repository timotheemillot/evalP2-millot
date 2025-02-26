import { Component } from '@angular/core';
import {RouterLink} from '@angular/router';
import {NgForOf} from '@angular/common';
import {PasswordsService} from '../../../services/passwords/passwords.service';
import {Password} from '../../../models/password';

@Component({
  selector: 'app-passwords-list',
  imports: [
    RouterLink,
    NgForOf
  ],
  templateUrl: './passwords-list.component.html',
  standalone: true,
  styleUrl: './passwords-list.component.css'
})
export class PasswordsListComponent {
  constructor(private passwordsService: PasswordsService) {
    this.loadPasswords();
  }

  passwords : Password[] = [];

  loadPasswords() {
    try{
      this.passwordsService.getPasswords().subscribe((data : Password[])=>{
        this.passwords = data;
      });
    }
    catch (e) {
      console.log(e);
    }
  }

  deletePassword(passwordId: number) {
    this.passwordsService.deletePassword(passwordId).subscribe({
      next: (response) => {
        this.loadPasswords();
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

}
