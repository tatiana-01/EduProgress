import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthComponent } from './components/auth/auth.component';
import { RolComponent } from './components/rol/rol.component';

export const routes: Routes = [

    {
        path: 'home',
        component: HomeComponent,
        loadChildren: () => import(`./components/home/home.route`).then(m => m.routes)
      },
      {
        path: 'auth',
        component: AuthComponent,
        loadChildren: () => import(`./components/auth/auth.route`).then(m => m.routes)
      },  {
        path: 'rol',
        component: RolComponent,
        loadChildren: () => import(`./components/rol/rol.route`).then(m => m.routes)
      }, 
      {
        path: '**',
        redirectTo: 'auth',
        pathMatch: 'full'
      }
];
