import { CanActivateFn } from '@angular/router';

export const sessionGuard: CanActivateFn = (route, state) => {
  if(localStorage.getItem("token")){
    return true;
  }
  return false;

};

