import {Application} from './application';

export class Password {
  id : number;
  username : string;
  content : string
  application : Application;

  constructor(id : number, username : string, content : string, application : Application) {
    this.id = id;
    this.username = username;
    this.content = content;
    this.application = application;
  }
}
