import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '', redirectTo: 'login', pathMatch: 'full'
  },
  { 
    path: 'user', loadChildren: () => import('./user/user.module').then(m => m.UserModule) 
  }, 
  { 
    path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) 
  },
  { path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
