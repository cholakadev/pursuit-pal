import './App.css';
import { Routes, Route } from 'react-router-dom';
import ErrorBoundary from './modules/core/components/errorBoundary';

const Home = () => <h1>Home Page</h1>;
const Register = () => <h1>Register Page</h1>;

const App = () => {
  return (
     <>
          <ErrorBoundary>
            <Routes>
            {/* <Route path="*" element={<NoMatch />} /> */}
              <Route path="/" element={<Home />} />
              <Route path="/register" element={<Register />} />
            </Routes>
          </ErrorBoundary>
     </>
  );
};


export default App;
