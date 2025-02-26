import { HttpInterceptorFn } from '@angular/common/http';
import {environment} from '../environnement.developpement';

export const apiKeyInterceptor: HttpInterceptorFn = (req, next) => {


  // Mise en place d’un service HTTP avec la clé d’API (incluse dans le header)
  req = req.clone({
    setHeaders: {
    'xapikey' : environment.apiKey
    }
  });

  return next(req);
};
