import { Routes } from '@angular/router';
import { RolComponent } from '../rol/rol.component';
import { AuthComponent } from './auth.component';

export const routes: Routes = [ 
  {
    path: '',  
    component: AuthComponent
  }
 ];

 /* {
    path: 'favorites',
    loadChildren: () => import(`../favorites/favorites.route`).then(m => m.routes)
  },
  {
    path: 'history',
    loadChildren: () => import(`../history/history.route`).then(m => m.routes)
  },
  {
    path: '**',
    redirectTo: '/tracks'
  } */