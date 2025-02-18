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
use App\DTO\ImageDTO;

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

    //add more images or change current ones here
    #[Route('/gallery', name: 'app_gallery')]
    public function gallery(): Response
    {
        $images = [];

        //create image object
        $image = new ImageDTO();
        //set image path (has to be inside assets/files/images)
        $image->setPath('food.jpg');
        //set image caption (optional)
        $image->setCaption('Most payed employee in the team.');
        //add image to array
        $images[] = $image;
        //done

        $image = new ImageDTO();
        $image->setPath('hospital2.jpg');
        $image->setCaption('Hospital sketch.');
        $images[] = $image;

        $image = new ImageDTO();
        $image->setPath('scene.jpg');
        $image->setCaption('Sketch of a scene.');
        $images[] = $image;

        $image = new ImageDTO();
        $image->setPath('Shipwreck_cinematicship_inverse.png');
        $image->setCaption('Part of a cutscene.');
        $images[] = $image;

        return $this->render('pages/gallery.html.twig', [
            'images' => $images
        ]);
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
