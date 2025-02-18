<?php

namespace App\Controller;

use App\Constant\General;
use App\Repository\GuestEntryRepository;
use Pagerfanta\Doctrine\ORM\QueryAdapter;
use Pagerfanta\Pagerfanta;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Attribute\Route;

final class PageController extends AbstractController{
    public function __construct(
        private readonly GuestEntryRepository $guestEntryRepository
    ) {
    }

    #[Route('/', name: 'app_home')]
    public function home(): Response
    {
        return $this->render('pages/home.html.twig');
    }

    #[Route('/gallery', name: 'app_gallery')]
    public function gallery(): Response
    {

        return $this->render('pages/home.html.twig');
    }

    #[Route('/guestbook', name: 'app_guestbook')]
    public function guestbook(Request $request): Response
    {
        $queryBuilder = $this->guestEntryRepository->getEntries(true);
        $adapter = new QueryAdapter($queryBuilder);
        $pagerfanta = Pagerfanta::createForCurrentPageWithMaxPerPage(
            $adapter,
            $request->query->get('page', 1),
            General::DEFAULT_ITEMS_PER_PAGE
        );

        return $this->render('pages/guestbook.html.twig',[
            'pagerfantaObject' => $pagerfanta,
            'maxItemsPerPage' => General::DEFAULT_ITEMS_PER_PAGE
        ]);
    }
}
