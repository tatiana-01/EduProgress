import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [

    {
        path: '',
        component: HomeComponent,
        loadChildren: () => import(`./components/home/home.route`).then(m => m.routes)
      }
];
