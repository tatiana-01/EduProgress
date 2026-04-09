import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthComponent } from './components/auth/auth.component';
import { RolComponent } from './components/rol/rol.component';
import { StudentsViewComponent } from './components/students-view/students-view.component';
import { sessionGuard } from './core/guards/session.guard';

export const routes: Routes = [

    {
        path: 'home',
        component: HomeComponent,
        loadChildren: () => import(`./components/home/home.route`).then(m => m.routes),
        canActivate:[sessionGuard]
      },
      {
        path: 'auth',
        component: AuthComponent,
        loadChildren: () => import(`./components/auth/auth.route`).then(m => m.routes)
      },  {
        path: 'rol',
        component: RolComponent,
        loadChildren: () => import(`./components/rol/rol.route`).then(m => m.routes),
        canActivate:[sessionGuard]
      }, 
      {
        path: 'estudiante',
        component: StudentsViewComponent,
        loadChildren: () => import(`./components/students-view/stu.route`).then(m => m.routes),
        canActivate:[sessionGuard]
      },
      {
        path: '**',
        redirectTo: 'auth',
        pathMatch: 'full'
      }
];
