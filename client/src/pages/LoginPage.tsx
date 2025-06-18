 import LoginForm from "../components/LoginForm";
 import  '../style/LoginPage.css';

 let LoginPage:React.FC = () =>{

  return(
      <div className="login-page">
        <div className="login-container">
          <LoginForm />
        </div>
      </div>
  );
 };

 export default LoginPage;