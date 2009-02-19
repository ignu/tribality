import Rhino.Commons.Binsor
import Rhino.Commons
import Tribality
import Tribality.Repository
import Tribality.Controllers
import Tribality.Services
import Tribality.Models

component "SessionBuilder", ISessionBuilder, HybridSessionBuilder
component "MessageRepository", IMessageRepository, MessageRepository
component "UserRepository", IUserRepository, UserRepository
component "PairRequestRepository", IPairRequestRepository, PairRequestRepository
component "BlogPostRepository", IBlogPostRepository, BlogPostRepository
component "CommentRepository", ICommentRepository, CommentRepository
component "LanguageRepository", ILanguageRepository, LanguageRepository

component "UserServices", IUserServices, UserServices
component "PostServices", IPostServices, PostServices
component "CommentRepository", ICommentRepository, CommentRepository

component "PostController", IPostController, PostController
component "AccountController", IAccountController, AccountController
component "ICommentController", ICommentController, CommentController
component "PairRequest", IPairRequestController, PairRequestController
